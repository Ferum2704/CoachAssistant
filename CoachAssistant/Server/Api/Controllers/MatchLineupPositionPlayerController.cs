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
    [Route("api/coaching-system/positionPlayers")]
    [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
    [ApiController]
    public class MatchLineupPositionPlayerController : ControllerBase
    {
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;
        private readonly IMatchLineupPositionPlayerService matchLineupPositionPlayerService;
        private readonly ICurrentUserService currentUserService;

        public MatchLineupPositionPlayerController(
            ICurrentUserService currentUserService,
            IMatchLineupPositionPlayerService matchLineupPositionPlayerService,
            IHubContext<NotificationsHub, INotificationsClient> hubContext)
        {
            this.currentUserService = currentUserService;
            this.matchLineupPositionPlayerService = matchLineupPositionPlayerService;
            this.hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateTeamLineup(MatchLineupPositionPlayerModel model)
        {
            var positionPlayer = await matchLineupPositionPlayerService.Add(model);

            return Ok(positionPlayer);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveByPositionId([FromQuery] Guid positionId)
        {
            await matchLineupPositionPlayerService.RemoveByPositionId(positionId);

            return Ok();
        }
    }
}
