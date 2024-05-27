using CoachAssistant.Client.Network;
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
    }
}
