using AuthPage.Model.Domain;
using AuthPage.Model.DTO;
using AuthPage.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegistrationRepository registrationRepository;
        private readonly ILoginRepository loginRepository;

        public AuthController(IRegistrationRepository registrationRepository,ILoginRepository loginRepository)
        {
            this.registrationRepository = registrationRepository;
            this.loginRepository = loginRepository;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistrationModel model)
        {
            var registration = await registrationRepository.RegisterUserAsync(model);
            if (registration != null)
            {
                if (registration.Succeeded)   { return Ok("User was registered!Please Login."); }   
            }
            return BadRequest("User registration failed.");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            var login = await loginRepository.LoginAsync(model);
            if (login != null)
            {
                var response = new LoginResponseDto
                {
                    JwtToken = login,
                };
                return Ok(response);
            }
            return Unauthorized("Invalid email or password.");
        }
    }
}
