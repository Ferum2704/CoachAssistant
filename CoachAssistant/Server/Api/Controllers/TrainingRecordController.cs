using Application.Abstractions;
using Application.Services.IService;
using CoachAssistant.Server.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoachAssistant.Server.Api.Controllers
{
    [Route("api/coaching-system/trainings/{trainingId}/trainingRecords")]
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
    }
}
