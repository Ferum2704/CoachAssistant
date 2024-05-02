using Application.Abstractions.IRepository;

namespace Application.Abstractions
{
    public interface IUnitOfWork
    {
        IManagerRepository ManagerRepository { get; }

        ICoachRepository CoachRepository { get; }

        IPlayerRepository PlayerRepository { get; }

        IClubRepository ClubRepository { get; }

        ITeamRepository TeamRepository { get; }

        Task SaveAsync();
    }
}
