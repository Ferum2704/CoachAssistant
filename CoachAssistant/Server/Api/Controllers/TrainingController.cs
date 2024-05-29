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
    [Route("api/coaching-system/teams/{teamId}/trainings")]
    [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService trainingService;
        private readonly ICurrentUserService currentUserService;
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;

        public TrainingController(IHubContext<NotificationsHub, INotificationsClient> hubContext, ICurrentUserService currentUserService, ITrainingService trainingService)
        {
            this.hubContext = hubContext;
            this.currentUserService = currentUserService;
            this.trainingService = trainingService;
        }

        [HttpPost]
        public async Task<IActionResult> PostTraining(Guid teamId, TrainingModel model)
        {
            model.TeamId = teamId;
            var trainingViewModel = await trainingService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).TrainingAddedNotification(trainingViewModel);

            return Ok(trainingViewModel);
        }

        [HttpGet("{trainingId}")]
        public async Task<IActionResult> GetTraining(Guid trainingId)
        {
            var trainingViewModel = await trainingService.Get(trainingId);

            return Ok(trainingViewModel);
        }

        [HttpPut("{trainingId}")]
        public async Task<IActionResult> Put(Guid trainingId, TrainingModel training)
        {
            var trainingViewModel = await trainingService.Edit(trainingId, training);

            return Ok(trainingViewModel);
        }

        [HttpDelete("{trainingId}")]
        public async Task<IActionResult> Delete(Guid trainingId)
        {
            await trainingService.Delete(trainingId);

            return Ok();
        }
    }
}
