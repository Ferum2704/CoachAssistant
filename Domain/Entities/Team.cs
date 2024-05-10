using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Team : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public VerificationState VerificationState { get; set; }

        public Guid ClubId { get; set; }

        public Club Club { get; set; }

        public Guid CoachId { get; set; }

        public Coach Coach { get; set; }

        public IReadOnlyCollection<Player> Players { get; set; }

        public IReadOnlyCollection<Training> Trainings { get; set; }

        public IReadOnlyCollection<Tournament> Tournaments { get; set; }

        public IReadOnlyCollection<TournamentTeam> TournamentTeams { get; set; }

        public IReadOnlyCollection<Match> Matches { get; set; }

        public IReadOnlyCollection<MatchTeam> MatchTeams { get; set; }
    }
}
