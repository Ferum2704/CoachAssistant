using Domain.Interfaces;

namespace Domain.Entities
{
    public class Tournament : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IReadOnlyCollection<Team> Teams { get; set; }

        public IReadOnlyCollection<TournamentTeam> TournamentTeams { get; set; }

        public IReadOnlyCollection<Match> Matches { get; set; }
    }
}
