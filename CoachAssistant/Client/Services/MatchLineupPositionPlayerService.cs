using CoachAssistant.Client.Network;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class MatchLineupPositionPlayerService
    {
        private readonly IHttpClientService httpClientService;

        public MatchLineupPositionPlayerService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task<MatchLineupPositionPlayerViewModel> Add(MatchLineupPositionPlayerModel model) =>
            await httpClientService.PostAsync<MatchLineupPositionPlayerModel, MatchLineupPositionPlayerViewModel>(ApiUrls.PositionsPlayersUrl, model);

        public async Task RemoveByPositionId(Guid positionId) =>
            await httpClientService.DeleteAsync(ApiUrls.GetRemovePlayersByPositionIdUrl(positionId));
    }
}
