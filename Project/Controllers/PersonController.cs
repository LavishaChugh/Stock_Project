using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Persons;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("Register")]

        public async Task<ActionResult<string>> Register(Register register)
        {
            var response = await _personService.Register(
                new Person
                {
                    Username = register.Username
                }, register.Password
                );

            return Ok(response);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(Login login)
        {
            var response = await _personService.Login(login.Username, login.Password);

            return Ok(response);
        }

    }
}
