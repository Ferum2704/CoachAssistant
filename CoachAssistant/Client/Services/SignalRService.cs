using Blazored.LocalStorage;
using CoachAssistant.Client.Network;
using CoachAssistant.Client.Network.NotificationHandlers;
using CoachAssistant.Shared.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;
using System.Reflection;

namespace CoachAssistant.Client.Services
{
    public class SignalRService
    {
        private HubConnection hubConnection;

        private readonly ILocalStorageService localStorageService;
        private readonly IServiceProvider serviceProvider;

        public SignalRService(ILocalStorageService localStorageService, IServiceProvider serviceProvider)
        {
            this.localStorageService = localStorageService;
            this.serviceProvider = serviceProvider;
        }

        public async Task StartConnectionAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(
                    "https://localhost:44308/notifications",
                    o => o.AccessTokenProvider = async () => await localStorageService.GetItemAsync<string>("AccessToken", default))
                .Build();

            hubConnection.On<ClubViewModel>(SignalREvents.TeamAddedNotification, Handle);
            hubConnection.On<PlayerViewModel>(SignalREvents.PlayerAddedNotification, Handle);

            await hubConnection.StartAsync();
        }

        public async Task StopConnectionAsync()
        {
            if (hubConnection != null && hubConnection.State == HubConnectionState.Connected)
            {
                await hubConnection.StopAsync();
            }
        }

        private void Handle<T>(T message)
        {
            var type = typeof(INotificationHandler<>).MakeGenericType(typeof(T));

            var handler = serviceProvider.GetService(type);
            
            ((INotificationHandler<T>)handler).Handle(message);
        }
    }
}
