namespace Project.Services.Persons
{
    public interface IPersonService
    {

        public Task<string> Register(Person person, string password);

        public Task<string> Login(string username, string password);

        public Task<bool> UserExists(string usename);
        

    }
}
