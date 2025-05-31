using AuthPage.Model.Domain;
using Microsoft.AspNetCore.Identity;

namespace AuthPage.Repository
{
    public interface IRegistrationRepository
    {
        Task<IdentityResult?> RegisterUserAsync(UserRegistrationModel userRegistrationModel);
    }
}
