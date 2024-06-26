﻿namespace CoachAssistant.Client.Entities
{
    public class TrainingViewEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public float Duration { get; set; }

        public Guid TeamId { get; set; }
    }
}
