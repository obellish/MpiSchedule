using System;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MpiSchedule.Client.Http;
using MpiSchedule.Components;
using MpiSchedule.Components.Account;
using MpiSchedule.Data;
using MpiSchedule.Hubs;
using MpiSchedule.Services;
using MpiSchedule.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddBlazorBootstrap();
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

var connectionString = builder.Configuration.GetConnectionString("DefaultDatabase") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContextFactory<PressScheduleContext>(options => options.UseSqlite(connectionString).EnableSensitiveDataLogging());
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>()
    .AddDbContextCheck<PressScheduleContext>();

builder.Services.AddTransient<IEmailSender, GmailEmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityEmailSender>();

builder.Services.AddCors(
    options => options.AddPolicy(
        "server",
        policy => policy.WithOrigins(builder.Configuration["FrontendUrl"] ?? "http://localhost:5286").AllowAnyHeader()
            .AllowAnyMethod()));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient<PressHttpClient>(BaseClient.ConfigureClient(builder.Configuration));
builder.Services.AddHttpClient<PressJobHttpClient>(BaseClient.ConfigureClient(builder.Configuration));

builder.Services.AddSignalR();

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddResponseCompression(
    options => { options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(["application/octet-stream"]); });

var app = builder.Build();

app.MapHealthChecks("/healthz");

await app.MigrateDatabaseAsync();

await using (var scope = app.Services.CreateAsyncScope())
{
    await using var pressScheduleContext = scope.ServiceProvider.GetRequiredService<PressScheduleContext>();

    await pressScheduleContext.SeedJobData();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("server");

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MpiSchedule.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.MapControllers();

app.MapHub<RefreshScheduleHub>("/refresh-schedule");

app.Run();