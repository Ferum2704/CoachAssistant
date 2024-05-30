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
    [Route("api/coaching-system/positions")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService positionService;
        private readonly ICurrentUserService currentUserService;
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;

        public PositionController(
            IHubContext<NotificationsHub, INotificationsClient> hubContext, 
            ICurrentUserService currentUserService, 
            IPositionService positionService)
        {
            this.hubContext = hubContext;
            this.currentUserService = currentUserService;
            this.positionService = positionService;
        }

        [HttpPost]
        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
        public async Task<IActionResult> PostPosition(PositionModel model)
        {
            var positionViewModel = await positionService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).PositionAddedNotification(positionViewModel);

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}, {nameof(ApplicationUserRole.Manager)}")]
        public async Task<IActionResult> GetAll()
        {
            var positions = await positionService.GetAll();

            return Ok(positions);
        }
    }
}
