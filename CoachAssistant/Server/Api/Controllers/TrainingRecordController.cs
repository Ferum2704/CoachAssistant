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
    [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
    [Route("api/coaching-system/trainingRecords")]
    [ApiController]
    public class TrainingRecordController : ControllerBase
    {
        private readonly ITrainingRecordService trainingRecordService;
        private readonly ICurrentUserService currentUserService;
        private readonly IHubContext<NotificationsHub, INotificationsClient> hubContext;

        public TrainingRecordController(IHubContext<NotificationsHub, INotificationsClient> hubContext, ICurrentUserService currentUserService, ITrainingRecordService trainingRecordService)
        {
            this.hubContext = hubContext;
            this.currentUserService = currentUserService;
            this.trainingRecordService = trainingRecordService;
        }

        [HttpPut("{trainingRecordId}")]
        public async Task<IActionResult> PutRecord(Guid trainingRecordId, TrainingRecordModel model)
        {
            var record = await trainingRecordService.Edit(trainingRecordId, model);

            return Ok(record);
        }

        [HttpPost("{trainingRecordId}/email")]
        public async Task<IActionResult> Sendmail(Guid trainingRecordId)
        {
            await trainingRecordService.SendRecordByEmail(trainingRecordId);

            return Ok();
        }

        [HttpGet("{trainingRecordId}")]
        public async Task<IActionResult> GetTrainingRecord(Guid trainingRecordId)
        {
            var trainingRecordViewModel = await trainingRecordService.Get(trainingRecordId);

            return Ok(trainingRecordViewModel);
        }
    }
}
