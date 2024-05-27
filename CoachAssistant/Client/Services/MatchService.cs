using CoachAssistant.Client.Network;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class MatchService
    {
        private readonly IHttpClientService httpClientService;

        public MatchService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task<MatchViewModel> GetById(string matchId) =>
            await httpClientService.GetAsync<MatchViewModel>(ApiUrls.GetMatchByIdUrl(matchId));
    }
}
