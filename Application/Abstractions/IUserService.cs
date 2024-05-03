using CoachAssistant.Shared.Models;

namespace Application.Abstractions
{
    public interface IUserService
    {
        Task<IdentityModel> Login(LoginModel loginModel);

        Task<bool> Register(RegistrationModel registrationModel);

        Task<string> RefreshToken(TokenModel tokensModel);

        Task Revoke();
    }
}
