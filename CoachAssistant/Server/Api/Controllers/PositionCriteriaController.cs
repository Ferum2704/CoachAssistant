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
    [Route("api/coaching-system/positionCriteria")]
    [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
    [ApiController]
    public class PositionCriteriaController : ControllerBase
    {
        private readonly IPositionCriteriaService positionCriteriaService;
        private readonly ICurrentUserService currentUserService;
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;

        public PositionCriteriaController(IPositionCriteriaService positionCriteriaService, ICurrentUserService currentUserService, IHubContext<NotificationsHub, INotificationsClient> hubContext)
        {
            this.positionCriteriaService = positionCriteriaService;
            this.currentUserService = currentUserService;
            this.hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostPositionCriteria(PositionCriteriaModel model)
        {
            var positionCriteriaViewModel = await positionCriteriaService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).PositionCriteriaAddedNotification(positionCriteriaViewModel);

            return Ok(positionCriteriaViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PositionCriteriaModel model)
        {
            var positionCriteria = await positionCriteriaService.Edit(id, model);

            return Ok(positionCriteria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await positionCriteriaService.Delete(id);

            return Ok();
        }
    }
}
