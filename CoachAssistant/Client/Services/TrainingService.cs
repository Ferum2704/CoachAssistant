using CoachAssistant.Client.Network;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class TrainingService
    {
        private readonly IHttpClientService httpClientService;

        public TrainingService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task<TrainingViewModel> Add(Guid teamId, TrainingModel model) =>
            await httpClientService.PostAsync<TrainingModel, TrainingViewModel>(ApiUrls.GetTrainingsUrl(teamId), model);

        public async Task<TrainingViewModel> Edit(Guid teamId, Guid trainingId, TrainingModel model) =>
            await httpClientService.PutAsync<TrainingModel, TrainingViewModel>(ApiUrls.GetTrainingByIdUrl(teamId, trainingId), model);

        public async Task Delete(Guid teamId, Guid trainingId) =>
            await httpClientService.DeleteAsync(ApiUrls.GetTrainingByIdUrl(teamId, trainingId));

        public async Task<TrainingViewModel> GetById(Guid teamId, Guid trainingId) =>
            await httpClientService.GetAsync<TrainingViewModel>(ApiUrls.GetTrainingByIdUrl(teamId, trainingId));
    }
}
