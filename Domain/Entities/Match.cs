using Domain.Interfaces;

namespace Domain.Entities
{
    public class Match : IEntity
    {
        public Guid Id { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public MatchType MatchType { get; set; }

        public Guid TournamentId { get; set; }

        public Tournament Tournament { get; set; }

        public IReadOnlyCollection<MatchPlayerAction> PlayerActions { get; set; }

        public IReadOnlyCollection<Team> Teams { get; set; }

        public IReadOnlyCollection<MatchTeam> MatchTeams { get; set; }
    }
}
