using CoachAssistant.Client.Network;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class MatchTeamService
    {
        private readonly IHttpClientService httpClientService;

        public MatchTeamService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task<MatchTeamViewModel> GetById(Guid matchTeamId) =>
            await httpClientService.GetAsync<MatchTeamViewModel>(ApiUrls.GetMatchTeamByIdUrl(matchTeamId));

        public async Task<MatchTeamViewModel> Edit(Guid matchTeamId, MatchTeamModel model) =>
            await httpClientService.PutAsync<MatchTeamModel, MatchTeamViewModel>(ApiUrls.GetMatchTeamByIdUrl(matchTeamId), model);

        public async Task<MatchTeamViewModel> CalculateLineup(Guid matchTeamId) =>
            await httpClientService.PostAsync<MatchTeamViewModel>(ApiUrls.GetLineupByMatchTeamIdUrl(matchTeamId));
    }
}
