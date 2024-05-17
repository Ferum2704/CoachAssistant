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
    [Route("api/coaching-system/tournamentTeams")]
    [ApiController]
    public class TournamentTeamController : ControllerBase
    {
        private readonly ITournamentTeamService tournamentTeamService;
        private readonly ICurrentUserService currentUserService;
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;

        public TournamentTeamController(
            IHubContext<NotificationsHub, INotificationsClient> hubContext, 
            ICurrentUserService currentUserService, 
            ITournamentTeamService tournamentTeamService)
        {
            this.hubContext = hubContext;
            this.currentUserService = currentUserService;
            this.tournamentTeamService = tournamentTeamService;
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Manager)}")]
        [HttpPost]
        public async Task<IActionResult> PostTournamentTeam(TournamentTeamModel model)
        {
            var tournamentTeamViewModel = await tournamentTeamService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).TournamentTeamAddedNotification(tournamentTeamViewModel);

            return Ok();
        }
    }
}
