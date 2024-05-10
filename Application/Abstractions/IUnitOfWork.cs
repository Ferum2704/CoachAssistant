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

        ITrainingRepository TrainingRepository { get; }

        ITrainingRecordRepository TrainingRecordRepository { get; }

        IPositionRepository PositionRepository { get; }

        ICriterionRepository CriterionRepository { get; }

        IPositionCriteriaRepository PositionCriteriaRepository { get; }

        Task SaveAsync();
    }
}
