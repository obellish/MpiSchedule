using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MpiSchedule.Data;

public class PressScheduleContext(DbContextOptions<PressScheduleContext> options, ILogger<PressScheduleContext> logger) : DbContext(options)
{
    public DbSet<Press> Presses { get; set; }

    public DbSet<PressJob> Jobs { get; set; }
    public override void Dispose()
    {
        logger.LogInformation("PressScheduleContext {Id} disposing", ContextId);
        base.Dispose();
    }

    public override ValueTask DisposeAsync()
    {
        logger.LogInformation("PressScheduleContext {Id} disposing asynchronously", ContextId);
        return base.DisposeAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var pressId = 0;
        modelBuilder.Entity<Press>().HasData(new Press { Name = "FlatBed Melzer", PressId = ++pressId });
        modelBuilder.Entity<Press>().HasData(new Press { Name = "Rotary Melzer", PressId = ++pressId });
        modelBuilder.Entity<Press>().HasData(new Press { Name = "10\"", PressId = ++pressId });
        modelBuilder.Entity<Press>().HasData(new Press { Name = "10Tam", PressId = ++pressId });
        modelBuilder.Entity<Press>().HasData(new Press { Name = "14\"Tamarack", PressId = ++pressId });
        modelBuilder.Entity<Press>().HasData(new Press { Name = "16\"Tamarack", PressId = ++pressId });
        modelBuilder.Entity<Press>().HasData(new Press { Name = "Test press", PressId = ++pressId });

        modelBuilder.Entity<Press>()
            .Property<byte[]>(ApplicationDbContext.RowVersion)
            .IsRowVersion();

        modelBuilder.Entity<PressJob>()
            .Property<byte[]>(ApplicationDbContext.RowVersion)
            .IsRowVersion();
    }
}