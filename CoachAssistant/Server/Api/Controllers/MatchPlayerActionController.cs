using Application.Abstractions;
using Application.Services.IService;
using CoachAssistant.Server.Hubs;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoachAssistant.Server.Api.Controllers
{
    [Route("api/coaching-system/playerActions")]
    [ApiController]
    public class MatchPlayerActionController : ControllerBase
    {
        private readonly IMatchPlayerActionService matchPlayerActionService;
        private readonly ICurrentUserService currentUserService;
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;

        public MatchPlayerActionController(
            IHubContext<NotificationsHub, INotificationsClient> hubContext,
            ICurrentUserService currentUserService,
            IMatchPlayerActionService matchPlayerActionService)
        {
            this.hubContext = hubContext;
            this.currentUserService = currentUserService;
            this.matchPlayerActionService = matchPlayerActionService;
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Manager)}")]
        [HttpPost]
        public async Task<IActionResult> PostPlayerAction(MatchPlayerActionModel model)
        {
            var playerActionViewModel = await matchPlayerActionService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).MatchPlayerActionAddedNotification(playerActionViewModel);

            return Ok();
        }
    }
}
