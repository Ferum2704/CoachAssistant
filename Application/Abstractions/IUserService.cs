using Application.DTOs;
using CoachAssistant.Shared.Models;

namespace Application.Abstractions
{
    public interface IUserService
    {
        Task<IdentityModel> Login(LoginDTO loginModel);

        Task<bool> Register(RegistrationDTO registrationModel);

        Task<string> RefreshToken(TokenModel tokensModel);

        Task Revoke();
    }
}
