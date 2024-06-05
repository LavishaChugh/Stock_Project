
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Project.Services.Persons
{
    public class PersonService : IPersonService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;


        public PersonService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public async Task<string> Login(string username, string password)
        {
            var response = "";
            var person = await _context.persons.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));

            if (person is null)
            {
                response = "NOT FOUND!";
            }

            else if (!VerifyPasswordHash(password, person.PasswordHash, person.PasswordSalt))
            {
                
                response = "Wrong Password";
            }
            else
            {
                response = CreateToken(person);
            }
            return response;
        }

        //REGISTER user
        public async Task<string> Register(Person person, string password)
        {
            var response = "";
            if (await UserExists(person.Username))  
            {
                response = "Already Exists";
                return response;
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt); 

            person.PasswordHash = passwordHash;
            person.PasswordSalt = passwordSalt;

            _context.persons.Add(person);
            await _context.SaveChangesAsync();

            response = "Registered Successfully!";
            return response;

        }


        //user EXISTS or not
        public async Task<bool> UserExists(string username)
        {
            if (await _context.persons.AnyAsync(c => c.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }


        //HASHING password
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);         
            }

        }


        //Creating TOKEN

        private string CreateToken(Person person)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, person.Id.ToString()),
                new Claim(ClaimTypes.Name, person.Username),

            };

            var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
            if (appSettingsToken is null)
            {
                throw new Exception("AppSettings token is null!");
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);       
        }

    }
}
