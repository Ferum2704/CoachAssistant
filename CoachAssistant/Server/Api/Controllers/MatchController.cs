using Application.Abstractions;
using Application.Services.IService;
using CoachAssistant.Server.Hubs;
using CoachAssistant.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoachAssistant.Server.Api.Controllers
{
    [Route("api/coaching-system/matchs")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService matchService;
        private readonly ICurrentUserService currentUserService;
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;

        public MatchController(IMatchService matchService, ICurrentUserService currentUserService, IHubContext<NotificationsHub, INotificationsClient> hubContext)
        {
            this.matchService = matchService;
            this.currentUserService = currentUserService;
            this.hubContext = hubContext;
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}, {nameof(ApplicationUserRole.Manager)}")]
        [HttpGet("{matchId}")]
        public async Task<IActionResult> GetById(Guid matchId)
        {
            var match = await matchService.Get(matchId);

            return Ok(match);
        }
    }
}
