using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Server.Hubs
{
    public interface INotificationsClient
    {
        Task HelloNotification(string message);

        Task TeamAddedNotification(ClubViewModel club);

        Task PlayerAddedNotification(PlayerViewModel player);
    }
}
