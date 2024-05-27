using CoachAssistant.Client.Network;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class PositionCriteriaService
    {
        private readonly IHttpClientService httpClientService;

        public PositionCriteriaService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task<List<PositionCriteriaViewModel>> EditRange(Dictionary<Guid, PositionCriteriaModel> models)
        {
            List<PositionCriteriaViewModel> result = new();
            foreach (var model in models)
            {
                var positionCriteriaViewModel = await httpClientService
                    .PutAsync<PositionCriteriaModel, PositionCriteriaViewModel>(ApiUrls.GetPositionCriteriaByIdUrl(model.Key), model.Value);
                result.Add(positionCriteriaViewModel);
            }

            return result;
        }

        public async Task<PositionCriteriaViewModel> Post(PositionCriteriaModel positionCriteriaModel) =>
            await httpClientService.PostAsync<PositionCriteriaModel, PositionCriteriaViewModel>(ApiUrls.PositionCriteriaUrl, positionCriteriaModel);

        public async Task Remove(Guid id) =>
            await httpClientService.DeleteAsync(ApiUrls.GetPositionCriteriaByIdUrl(id));
    }
}
