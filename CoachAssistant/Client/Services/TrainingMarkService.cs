using CoachAssistant.Client.Network;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class TrainingMarkService
    {
        private readonly IHttpClientService httpClientService;

        public TrainingMarkService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task<TrainingMarkViewModel> Add(TrainingMarkModel model) =>
            await httpClientService.PostAsync<TrainingMarkModel, TrainingMarkViewModel>(ApiUrls.TrainingMarksUrl, model);

        public async Task<TrainingMarkViewModel> Edit(Guid trainingMarkId, TrainingMarkModel model) =>
            await httpClientService.PutAsync<TrainingMarkModel, TrainingMarkViewModel>(ApiUrls.GetTrainingMarkByIdUrl(trainingMarkId), model);
    }
}
