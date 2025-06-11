using DI.Contracts.Model.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.DAL.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ITokenRepository tokenRepository;
        private readonly UserManager<IdentityUser> userManager;

        public LoginRepository(ITokenRepository tokenRepository,UserManager<IdentityUser> userManager)
        {
            this.tokenRepository = tokenRepository;
            this.userManager = userManager;
        }
        public async Task<string?> LoginAsync(UserLoginModel userLoginModel)
        {
            var user = await userManager.FindByEmailAsync(userLoginModel.Email);
            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, userLoginModel.Password);
                if (result)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    return tokenRepository.CreateToken(user, roles.ToList());
                }
            }
            return null;
        }
    }
}
