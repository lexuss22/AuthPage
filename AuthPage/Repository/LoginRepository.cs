using AuthPage.Model.Domain;
using Microsoft.AspNetCore.Identity;

namespace AuthPage.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenCreate tokenCreate;

        public LoginRepository(UserManager<IdentityUser> userManager,ITokenCreate tokenCreate)
        {
            this.userManager = userManager;
            this.tokenCreate = tokenCreate;
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
                    return tokenCreate.CreateTokenAsync(user, roles.ToList());
                }
            }
            return null;
        }
    }
}
