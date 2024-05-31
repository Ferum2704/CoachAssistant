using CoachAssistant.Client.Network;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class TrainingRecordService
    {
        private readonly IHttpClientService httpClientService;

        public TrainingRecordService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task<TrainingRecordViewModel> Edit(Guid recordId, TrainingRecordModel model) =>
            await httpClientService.PutAsync<TrainingRecordModel, TrainingRecordViewModel>(ApiUrls.GetTrainingRecordByIdUrl(recordId), model);

        public async Task SendRecordByEmail(Guid recordId) =>
            await httpClientService.PostAsync(ApiUrls.GetTrainingRecordEmailUrl(recordId));
    }
}
