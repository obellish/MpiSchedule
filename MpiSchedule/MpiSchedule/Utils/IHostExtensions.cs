using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MpiSchedule.Data;

namespace MpiSchedule.Utils;

// ReSharper disable once InconsistentNaming
public static class IHostExtensions
{
    public static async Task MigrateDatabaseAsync(this IHost host, CancellationToken cancellationToken = default)
    {
        await using var scope = host.Services.CreateAsyncScope();
        await using (var userContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            await userContext.Database.MigrateAsync(cancellationToken);
        }

        await using (var pressScheduleContext = scope.ServiceProvider.GetRequiredService<PressScheduleContext>())
        {
            await pressScheduleContext.Database.MigrateAsync(cancellationToken);
        }
    }
}