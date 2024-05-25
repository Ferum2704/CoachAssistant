using Application.Abstractions;
using Application.Services.IService;
using CoachAssistant.Server.Hubs;
using CoachAssistant.Shared;
using CoachAssistant.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoachAssistant.Server.Api.Controllers
{
    [Route("api/coaching-system/teams/{teamId}/players")]
    [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
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

        [HttpPost]
        public async Task<IActionResult> PostPlayer(Guid teamId, PlayerModel model)
        {
            model.TeamId = teamId;
            var playerViewModel = await playerService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).PlayerAddedNotification(playerViewModel);

            return Ok(playerViewModel);
        }

        [HttpGet("{playerId}")]
        public async Task<IActionResult> GetById(Guid playerId)
        {
            var playerViewModel = await playerService.Get(playerId);

            return Ok(playerViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetByTeamIdAsync([FromQuery] Guid teamId)
        {
            var players = await playerService.GetPlayersByTeamIdAsync(teamId);

            return Ok(players);
        }
    }
}
