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
    [Route("api/coaching-system/tournaments")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;
        private readonly ITournamentService tournamentService;
        private readonly ICurrentUserService currentUserService;

        public TournamentController(ICurrentUserService currentUserService, ITournamentService tournamentService, IHubContext<NotificationsHub, INotificationsClient> hubContext)
        {
            this.currentUserService = currentUserService;
            this.tournamentService = tournamentService;
            this.hubContext = hubContext;
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Manager)}")]
        [HttpPost]
        public async Task<IActionResult> PostTournament(TournamentModel model)
        {
            var tournamentViewModel = await tournamentService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).TournmanetAddedNotification(tournamentViewModel);

            return Ok();
        }
    }
}
