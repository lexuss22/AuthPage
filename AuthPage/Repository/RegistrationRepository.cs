using AuthPage.Model.Domain;
using Microsoft.AspNetCore.Identity;

namespace AuthPage.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly UserManager<IdentityUser> userManager;

        public RegistrationRepository(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IdentityResult?> RegisterUserAsync(UserRegistrationModel userRegistrationModel)
        {
            var user = new IdentityUser
            {
                UserName = userRegistrationModel.Email,
                Email = userRegistrationModel.Email
            };

            if (userRegistrationModel != null)
            {
                var result = await userManager.CreateAsync(user, userRegistrationModel.Password);
                if(result.Succeeded)
                {
                    if(userRegistrationModel.Roles != null && userRegistrationModel.Roles.Any())
                    {
                        result = await userManager.AddToRolesAsync(user, userRegistrationModel.Roles);
                        if (result.Succeeded)
                        {
                            return result;
                        }
                    }
                }
            }
            return null;
        }
    }
}
