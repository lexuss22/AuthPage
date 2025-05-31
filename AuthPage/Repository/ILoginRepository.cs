using AuthPage.Model.Domain;

namespace AuthPage.Repository
{
    public interface ILoginRepository
    {
        Task<string?> LoginAsync(UserLoginModel userLoginModel);
    }
}
