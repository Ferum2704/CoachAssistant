namespace CoachAssistant.Client.Network.NotificationHandlers
{
    public interface INotificationHandler<T>
    {
        void Handle(T notification);
    }
}
