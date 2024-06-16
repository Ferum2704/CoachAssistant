using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace Application.Services.IService
{
    public interface IPlayerService : IService<PlayerModel, PlayerViewModel>
    {
        Task<IReadOnlyCollection<PlayerViewModel>> GetPlayersByTeamIdAsync(Guid teamId);

        Task<List<PlayerViewModel>> AddRange(PlayerModel[] models);
    }
}
