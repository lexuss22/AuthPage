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
        private readonly IAuthServices authServices;

        public AuthController(IAuthServices authServices)
        {
            this.authServices = authServices;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistrationRequest model)
        {
            var result = await authServices.Regist(model);
            if (result != null)
            {
                return Ok("User was registered!Please Login.");    
            }
            return BadRequest("User registration failed.");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest model)
        {
            var result = await authServices.Login(model);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized("Invalid email or password.");
        }
    }
}
