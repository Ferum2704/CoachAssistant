using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Entities
{
    public class MatchViewEntity
    {
        public Guid Id { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public MatchType MatchType { get; set; }

        public Guid TournamentId { get; set; }

        public IReadOnlyCollection<MatchTeamViewModel> MatchTeams { get; set; }
    }
}
