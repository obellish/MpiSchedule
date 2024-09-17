using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MpiSchedule.Client;
using MpiSchedule.Client.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddBlazorBootstrap();

builder.Services.AddHttpClient<PressHttpClient>(PressHttpClient.ConfigureClient(builder.Configuration));
builder.Services.AddHttpClient<PressJobHttpClient>(PressHttpClient.ConfigureClient(builder.Configuration));

await builder.Build().RunAsync();
