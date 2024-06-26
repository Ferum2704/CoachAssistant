﻿namespace CoachAssistant.Shared.ViewModels
{
    public class MatchViewModel
    {
        public Guid Id { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public MatchType MatchType { get; set; }

        public Guid TournamentId { get; set; }

        public TournamentViewModel Tournament { get; set; }

        public IReadOnlyCollection<MatchTeamViewModel> MatchTeams { get; set; }
    }
}
