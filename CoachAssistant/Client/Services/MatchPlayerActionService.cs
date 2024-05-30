using CoachAssistant.Client.Network;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class MatchPlayerActionService
    {
        private readonly IHttpClientService httpClientService;

        public MatchPlayerActionService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task<List<ActionTypeViewModel>> GetAllActionTypes() =>
            await httpClientService.GetAsync<List<ActionTypeViewModel>>(ApiUrls.ActionTypesUrl);

        public async Task<MatchPlayerActionViewModel> Add(MatchPlayerActionModel model) =>
            await httpClientService.PostAsync<MatchPlayerActionModel, MatchPlayerActionViewModel>(ApiUrls.MatchPlayerActionsUrl, model);

        public async Task<MatchPlayerActionViewModel> Edit(Guid actionId, MatchPlayerActionModel model) =>
            await httpClientService.PutAsync<MatchPlayerActionModel, MatchPlayerActionViewModel>(ApiUrls.GetMatchPlayerActionByIdUrl(actionId), model);
    }
}
