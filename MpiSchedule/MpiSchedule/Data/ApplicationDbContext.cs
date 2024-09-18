using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MpiSchedule.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger) : IdentityDbContext<ApplicationUser>(options)
{
    private static readonly string RowVersion = nameof(RowVersion);

    public override void Dispose()
    {
        logger.LogInformation("ApplicationDbContext {Id} disposing", ContextId);
        base.Dispose();
    }

    public override ValueTask DisposeAsync()
    {
        logger.LogInformation("ApplicationDbContext {Id} disposing asynchronously", ContextId);
        return base.DisposeAsync();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {
                    Name = "User", NormalizedName = "USER",
                },
                new IdentityRole
                {
                    Name = "Admin", NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Name = "Developer", NormalizedName = "DEV",
                });

        builder.Entity<ApplicationUser>()
            .Property<byte[]>(RowVersion)
            .IsRowVersion();
            

        base.OnModelCreating(builder);
    }
}