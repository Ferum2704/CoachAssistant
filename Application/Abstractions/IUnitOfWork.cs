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

        ITournamentRepository TournamentRepository { get; }

        IMatchRepository MatchRepository { get; }

        IMatchTeamRepository MatchTeamRepository { get; }

        IMatchPlayerActionRepository MatchPlayerActionRepository { get; }

        IMatchLineupPositionRepository MatchLineupPositionRepository { get; }

        IMatchLineupPositionPlayerRepository MatchLineupPositionPlayerRepository { get; }

        IActionTypeRepository ActionTypeRepository { get; }

        ITournamentTeamRepository TournamentTeamRepository { get; }

        Task SaveAsync();
    }
}
