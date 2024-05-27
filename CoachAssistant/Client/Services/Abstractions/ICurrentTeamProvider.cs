using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services.Abstractions
{
    public interface ICurrentTeamProvider
    {
        public ClubViewModel CurrentClub {  get; set; }
    }
}
