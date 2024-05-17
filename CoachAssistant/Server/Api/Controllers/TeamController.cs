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
    [Route("api/coaching-system/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;
        private readonly IClubService clubService;
        private readonly ICurrentUserService currentUserService;

        public TeamController(IHubContext<NotificationsHub, INotificationsClient> hubContext, IClubService clubService, ICurrentUserService currentUserService)
        {
            this.hubContext = hubContext;
            this.clubService = clubService;
            this.currentUserService = currentUserService;
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
        [HttpPost]
        public async Task<IActionResult> PostTeam(TeamClubModel model)
        {
            var clubViewModel = await clubService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).TeamAddedNotification(clubViewModel);

            return Ok();
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
        [HttpGet("coach")]
        public async Task<IActionResult> GetCoachTeam()
        {
            var teamViewModel = await clubService.GetByCoachId(currentUserService.CurrentUserId);

            return Ok(teamViewModel);
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Manager)}")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await clubService.GetAll();

            return Ok(teams);
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
        [HttpGet]
        public async Task<IActionResult> DeleteClub(Guid clubId)
        {
            await clubService.Delete(clubId);

            return Ok();
        }
    }
}
