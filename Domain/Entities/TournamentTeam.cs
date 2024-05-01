using Domain.Interfaces;

namespace Domain.Entities
{
    public class TournamentTeam : IEntity
    {
        public Guid Id { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        public Guid TournamentId { get; set; }

        public Tournament Tournament { get; set; }
    }
}
