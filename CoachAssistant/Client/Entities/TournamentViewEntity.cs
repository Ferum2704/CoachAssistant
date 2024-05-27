using CoachAssistant.Shared;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Entities
{
    public class TournamentViewEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TournamentType TournamentType { get; set; }

        public IReadOnlyCollection<MatchViewEntity> Matches { get; set; }
    }
}
