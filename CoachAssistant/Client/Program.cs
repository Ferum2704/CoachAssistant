using Blazored.LocalStorage;
using CoachAssistant.Client;
using CoachAssistant.Client.Configurations;
using CoachAssistant.Client.Network;
using CoachAssistant.Client.Network.NotificationHandlers;
using CoachAssistant.Client.Services;
using CoachAssistant.Client.Services.Abstractions;
using CoachAssistant.Shared.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("CoachAssistant.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CoachAssistant.ServerAPI"));
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddSingleton(AutoMapperConfiguration.ResolveMapper());
builder.Services.AddTransient<SignalRService>();
builder.Services.AddTransient<INotificationHandler<ClubViewModel>, TeamAddedNotificationHandler>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ICurrentTeamProvider, CurrentTeamProvider>();

await builder.Build().RunAsync();
