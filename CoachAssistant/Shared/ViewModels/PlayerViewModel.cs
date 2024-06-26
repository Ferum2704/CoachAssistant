﻿namespace CoachAssistant.Shared.ViewModels
{
    public class PlayerViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        public string Email { get; set; }

        public IReadOnlyCollection<TrainingRecordViewModel> TrainingRecords { get; set; }

        public List<MatchPlayerActionViewModel> MatchPlayerActions { get; set; }
    }
}
