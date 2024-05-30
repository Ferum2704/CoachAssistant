using CoachAssistant.Client.Network;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class TeamService
    {
        public List<ClubViewModel> Teams { get; private set; } = new();
        public Dictionary<Guid, List<ClubViewModel>> TournamentsTeams { get; private set; } = new();

        private readonly IHttpClientService httpClientService;

        public TeamService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task LoadTeams() =>
            Teams = await httpClientService.GetAsync<List<ClubViewModel>>(ApiUrls.TeamsUrl);

        public async Task<List<ClubViewModel>> GetTournamentTeams(Guid tournamentId)
        {
            if (!TournamentsTeams.ContainsKey(tournamentId))
            {
                var teams = await httpClientService.GetAsync<List<ClubViewModel>>(ApiUrls.GetTournamentTeamsUrl(tournamentId));
                TournamentsTeams[tournamentId] = teams;
            }

            return TournamentsTeams[tournamentId];
        }
    }
}
