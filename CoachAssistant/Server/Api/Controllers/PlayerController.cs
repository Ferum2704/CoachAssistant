using Application.Abstractions;
using Application.Services;
using Application.Services.IService;
using CoachAssistant.Server.Hubs;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoachAssistant.Server.Api.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;
        private readonly ICurrentUserService currentUserService;
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;

        public PlayerController(IPlayerService playerService, ICurrentUserService currentUserService, IHubContext<NotificationsHub, INotificationsClient> hubContext)
        {
            this.playerService = playerService;
            this.currentUserService = currentUserService;
            this.hubContext = hubContext;
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
        [HttpPost]
        public async Task<IActionResult> PostTeam(PlayerModel model)
        {
            var playerViewModel = await playerService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).PlayerAddedNotification(playerViewModel);

            return Ok();
        }
    }
}
