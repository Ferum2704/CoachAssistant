using Application.Abstractions;
using Application.Services.IService;
using CoachAssistant.Server.Hubs;
using CoachAssistant.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoachAssistant.Server.Api.Controllers
{
    [Route("api/coaching-system/matchTeams")]
    [ApiController]
    public class MatchTeamController : ControllerBase
    {
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;
        private readonly IMatchTeamService matchTeamService;
        private readonly ICurrentUserService currentUserService;

        public MatchTeamController(
            ICurrentUserService currentUserService, 
            IMatchTeamService matchTeamService, 
            IHubContext<NotificationsHub, INotificationsClient> hubContext)
        {
            this.currentUserService = currentUserService;
            this.matchTeamService = matchTeamService;
            this.hubContext = hubContext;
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
        [HttpPost("{matchTeamId}/lineup")]
        public async Task<IActionResult> CalculateTeamLineup(Guid matchTeamId)
        {
            var matchTeam = await matchTeamService.CalculateLineUp(matchTeamId);

            return Ok(matchTeam);
        }
    }
}
