using CoachAssistant.Client.Network;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class TeamService
    {
        public List<ClubViewModel> Teams { get; private set; } = new();

        private readonly IHttpClientService httpClientService;

        public TeamService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task LoadTeams() =>
            Teams = await httpClientService.GetAsync<List<ClubViewModel>>(ApiUrls.TeamsUrl);

        public List<TeamViewModel> GetTournamentsTeams(List<Guid> teamIds)
        {
            var teams = Teams.Where(x => teamIds.Contains(x.Team.Id)).Select(x => x.Team).ToList();

            return teams;
        }
    }
}
