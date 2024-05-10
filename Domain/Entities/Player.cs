namespace Domain.Entities
{
    public class Player : DomainUser
    {
        public float Height { get; set; }

        public float Weight { get; set; }

        public string Email { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        public IReadOnlyCollection<TrainingRecord> TrainingRecords { get; set; }

        public IReadOnlyCollection<MatchLineupPosition> MatchLineupPositions { get; set; }

        public IReadOnlyCollection<MatchLineupPositionPlayer> MatchLineupPositionsPlayers { get; set; }

        public IReadOnlyCollection<MatchPlayerAction> MatchPlayerActions { get; set; }
    }
}
