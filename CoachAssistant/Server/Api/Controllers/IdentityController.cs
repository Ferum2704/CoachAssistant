using Application.Abstractions;
using Application.DTOs;
using CoachAssistant.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoachAssistant.Server.Api.Controllers
{
    [Route("api/coaching-system/identity/")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IUserService userService;

        public IdentityController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO loginModel)
        {
            var tokenModel = await userService.Login(loginModel);

            if (string.IsNullOrEmpty(tokenModel.Tokens.AccessToken) || string.IsNullOrEmpty(tokenModel.Tokens.AccessToken))
            {
                return Unauthorized();
            }

            return Ok(tokenModel);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationDTO registrationModel)
        {
            var isSuccessful = await userService.Register(registrationModel);

            if (!isSuccessful)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(isSuccessful);
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(TokenModel tokensModel)
        {
            var newAccessToken = await userService.RefreshToken(tokensModel);

            if (string.IsNullOrEmpty(newAccessToken))
            {
                return BadRequest("Provided token are invalid");
            }

            return Ok(newAccessToken);
        }

        [HttpPost]
        [Authorize]
        [Route("revoke")]
        public async Task<IActionResult> Revoke()
        {
            await userService.Revoke();

            return NoContent();
        }
    }
}
