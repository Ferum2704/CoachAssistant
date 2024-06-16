using CoachAssistant.Client.Network;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class PlayerService
    {
        private readonly IHttpClientService httpClientService;

        public PlayerService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task<PlayerViewModel> Add(Guid teamId, PlayerModel model) =>
            await httpClientService.PostAsync<PlayerModel, PlayerViewModel>(ApiUrls.GetPlayersUrl(teamId), model);

        public async Task<PlayerViewModel> Edit(Guid teamId, string playerId, PlayerModel model) =>
            await httpClientService.PutAsync<PlayerModel, PlayerViewModel>(ApiUrls.GetPlayerByIdUrl(teamId, playerId), model);

        public async Task Delete(Guid teamId, string playerId) =>
            await httpClientService.DeleteAsync(ApiUrls.GetPlayerByIdUrl(teamId, playerId));

        public async Task<PlayerViewModel> GetById(Guid teamId, string playerId) =>
            await httpClientService.GetAsync<PlayerViewModel>(ApiUrls.GetPlayerByIdUrl(teamId, playerId));

        public async Task<List<PlayerViewModel>> GetByTeamId(Guid teamId) =>
            await httpClientService.GetAsync<List<PlayerViewModel>>(ApiUrls.GetPlayersByTeamIdUrl(teamId));
    }
}
