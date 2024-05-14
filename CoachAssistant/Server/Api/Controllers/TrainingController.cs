using Application.Abstractions;
using Application.Services;
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

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
        [HttpPost]
        public async Task<IActionResult> PostTraining(Guid teamId, TrainingModel model)
        {
            model.TeamId = teamId;
            var trainingViewModel = await trainingService.Add(model);

            await hubContext.Clients.User(currentUserService.CurrentUserId.ToString()).TrainingAddedNotification(trainingViewModel);

            return Ok();
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
        [HttpGet("{trainingId}")]
        public async Task<IActionResult> GetTraining(Guid trainingId)
        {
            var trainingViewModel = await trainingService.Get(trainingId);

            return Ok(trainingViewModel);
        }
    }
}
