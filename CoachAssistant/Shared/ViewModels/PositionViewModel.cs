namespace CoachAssistant.Shared.ViewModels
{
    public class PositionViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<PositionCriteriaViewModel> Criteria { get; set; }
    }
}
