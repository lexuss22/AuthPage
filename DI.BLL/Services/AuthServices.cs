using DI.Contracts.Model.Domain;
using DI.Contracts.Model.DTO;
using DI.DAL.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.BLL.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly ILoginRepository loginRepository;
        private readonly IRegistrationRepository registrationRepository;

        public AuthServices(ILoginRepository loginRepository,IRegistrationRepository registrationRepository)
        {
            this.loginRepository = loginRepository;
            this.registrationRepository = registrationRepository;
        }
        public async Task<LoginResponseDto?> Login(UserLoginRequest userLoginModel)
        {
            if (userLoginModel != null)
            {
                var result = await loginRepository.LoginAsync(userLoginModel);
                if (result != null)
                {
                    var response = new LoginResponseDto
                    {
                        JwtToken = result
                    };
                    return response;
                }
            }
            return null;
        }

        public async Task<IdentityResult?> Regist(UserRegistrationRequest userRegistrationModel)
        {
            if (userRegistrationModel != null)
            {
                var result = await registrationRepository.RegisterUserAsync(userRegistrationModel);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
