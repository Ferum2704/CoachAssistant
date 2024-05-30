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
    [Route("api/coaching-system/actionTypes")]
    [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}, {nameof(ApplicationUserRole.Manager)}")]
    [ApiController]
    public class ActionTypeController : ControllerBase
    {
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;
        private readonly IActionTypeService actionTypeService;
        private readonly ICurrentUserService currentUserService;

        public ActionTypeController(
            ICurrentUserService currentUserService, 
            IActionTypeService actionTypeService, 
            IHubContext<NotificationsHub, INotificationsClient> hubContext)
        {
            this.currentUserService = currentUserService;
            this.actionTypeService = actionTypeService;
            this.hubContext = hubContext;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostActionType(ActionTypeModel model)
        {
            var actionTypeViewModel = await actionTypeService.Add(model);

            return Ok(actionTypeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetActionTypes()
        {
            var actionTypes = await actionTypeService.GetAll();

            return Ok(actionTypes);
        }
    }
}
