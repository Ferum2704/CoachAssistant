using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace Application.Services.IService
{
    public interface IMatchLineupPositionPlayerService : IService<MatchLineupPositionPlayerModel, MatchLineupPositionPlayerViewModel>
    {
        Task RemoveByPositionId(Guid positionId);
    }
}
