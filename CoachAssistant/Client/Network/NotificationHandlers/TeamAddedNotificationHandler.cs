using CoachAssistant.Client.Services.Abstractions;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Network.NotificationHandlers
{
    public class TeamAddedNotificationHandler : INotificationHandler<ClubViewModel>
    {
        private readonly ICurrentTeamProvider currentTeamProvider;

        public TeamAddedNotificationHandler()
        {
            
        }

        public TeamAddedNotificationHandler(ICurrentTeamProvider currentTeamProvider)
        {
            this.currentTeamProvider = currentTeamProvider;
        }

        public void Handle(ClubViewModel notification)
        {
            currentTeamProvider.Set(notification);
        }
    }
}
