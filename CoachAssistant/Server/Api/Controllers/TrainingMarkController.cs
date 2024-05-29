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
    [Route("api/coaching-system/trainingMarks")]
    [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
    [ApiController]
    public class TrainingMarkController : ControllerBase
    {
        private readonly ITrainingMarkService trainingMarkService;
        private readonly ICurrentUserService currentUserService;
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;

        public TrainingMarkController(
            IHubContext<NotificationsHub, INotificationsClient> hubContext, 
            ICurrentUserService currentUserService, 
            ITrainingMarkService trainingMarkService)
        {
            this.hubContext = hubContext;
            this.currentUserService = currentUserService;
            this.trainingMarkService = trainingMarkService;
        }

        [HttpPost]
        public async Task<IActionResult> PostTrainingMark(TrainingMarkModel model)
        {
            var trainingMarkViewModel = await trainingMarkService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).TrainingMarkAddedNotification(trainingMarkViewModel);

            return Ok(trainingMarkViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TrainingMarkModel model)
        {
            var trainingMarkViewModel = await trainingMarkService.Edit(id, model);

            return Ok(trainingMarkViewModel);
        }
    }
}
