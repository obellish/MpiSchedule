using System;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MpiSchedule.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddBlazorBootstrap();

builder.Services.AddHttpClient<PressHttpClient>(client => client.BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:7088"));

await builder.Build().RunAsync();
