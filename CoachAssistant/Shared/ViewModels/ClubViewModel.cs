namespace CoachAssistant.Shared.ViewModels
{
    public class ClubViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Stadium { get; set; }

        public TeamViewModel Team { get; set; }
    }
}
