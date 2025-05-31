using Microsoft.AspNetCore.Identity;

namespace AuthPage.Repository
{
    public interface ITokenCreate
    {
        string CreateTokenAsync(IdentityUser user, List<string> roles);
    }
}
