using CoachAssistant.Client.Network;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class TournamentTeamService
    {

        private readonly IHttpClientService httpClientService;

        public TournamentTeamService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task<TournamentTeamViewModel> Post(TournamentTeamModel model) =>
            await httpClientService.PostAsync<TournamentTeamModel, TournamentTeamViewModel>(ApiUrls.TournamentTeamsUrl, model);

        public async Task Delete(Guid tournamentTeamId) =>
            await httpClientService.DeleteAsync(ApiUrls.GetTournamentTeamByIdUrl(tournamentTeamId));
    }
}
