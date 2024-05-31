using Application.Abstractions;
using Application.Services;
using Application.Services.IService;
using CoachAssistant.Server.Hubs;
using CoachAssistant.Shared;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
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

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).TournamentAddedNotification(tournamentViewModel);

            return Ok(tournamentViewModel);
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Manager)}")]
        [HttpPost("{tournamentId}/matches")]
        public async Task<IActionResult> PostTournamentMatches(Guid tournamentId)
        {
            var tournament = await tournamentService.GenerateTournamentMatches(tournamentId);

            return Ok(tournament);
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)},{nameof(ApplicationUserRole.Manager)}")]
        [HttpGet("{tournamentId}")]
        public async Task<IActionResult> GetTournament(Guid tournamentId)
        {
            var tournament = await tournamentService.Get(tournamentId);

            return Ok(tournament);
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)},{nameof(ApplicationUserRole.Manager)}")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Guid? teamId)
        {
            IReadOnlyCollection<TournamentViewModel> tournaments;
            if (teamId.HasValue)
            {
                tournaments = await tournamentService.GetByTeamId(teamId.Value);
            }
            else
            {
                tournaments = await tournamentService.GetAll();
            }

            return Ok(tournaments);
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Manager)}")]
        [HttpPut("{tournamentId}")]
        public async Task<IActionResult> Put(Guid tournamentId, TournamentModel model)
        {
            var tournamentViewModel = await tournamentService.Edit(tournamentId, model);

            return Ok(tournamentViewModel);
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Manager)}")]
        [HttpDelete("{tournamentId}")]
        public async Task<IActionResult> Delete(Guid tournamentId)
        {
            await tournamentService.Delete(tournamentId);

            return Ok();
        }
    }
}
