using DI.Contracts.Model.Domain;
using DI.Contracts.Model.DTO;
using DI.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.BLL.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly ILoginRepository loginRepository;

        public LoginServices(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public async Task<LoginResponseDto?> Login(UserLoginModel userLoginModel)
        {
            if(userLoginModel != null)
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
    }
}
