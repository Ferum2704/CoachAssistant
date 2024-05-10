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
    [Route("api/coaching-system/criteria")]
    [ApiController]
    public class CriterionController : ControllerBase
    {
        private readonly ICriterionService criterionService;
        private readonly ICurrentUserService currentUserService;
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;

        public CriterionController(ICriterionService criterionService, ICurrentUserService currentUserService, IHubContext<NotificationsHub, INotificationsClient> hubContext)
        {
            this.criterionService = criterionService;
            this.currentUserService = currentUserService;
            this.hubContext = hubContext;
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
        [HttpPost]
        public async Task<IActionResult> PostCritetion(CriterionModel model)
        {
            var criterionViewModel = await criterionService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).CriterionAddedNotification(criterionViewModel);

            return Ok();
        }
    }
}
