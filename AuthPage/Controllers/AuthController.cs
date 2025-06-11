using DI.BLL.Services;
using DI.Contracts.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace AuthPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegistrationServices registrationServices;
        private readonly ILoginServices loginServices;

        public AuthController(IRegistrationServices registrationServices,ILoginServices loginServices)
        {
            this.registrationServices = registrationServices;
            this.loginServices = loginServices;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistrationModel model)
        {
            var result = await registrationServices.Regist(model);
            if (result != null)
            {
                return Ok("User was registered!Please Login.");    
            }
            return BadRequest("User registration failed.");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            var result = await loginServices.Login(model);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized("Invalid email or password.");
        }
    }
}
