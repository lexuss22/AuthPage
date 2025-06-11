using DI.Contracts.Model.Domain;
using DI.Contracts.Model.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.BLL.Services
{
    public interface IAuthServices
    {
        Task<LoginResponseDto?> Login(UserLoginRequest userLoginModel);
        Task<IdentityResult?> Regist(UserRegistrationRequest userRegistrationModel);
    }
}
