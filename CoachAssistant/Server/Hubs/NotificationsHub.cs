using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CoachAssistant.Server.Hubs
{
    public class NotificationsHub : Hub<INotificationsClient>
    {
        [Authorize]
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).HelloNotification($"Hello {Context.User.Identity.Name}");

            await base.OnConnectedAsync();
        }
    }
}
