using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MpiSchedule.Client.Models;

namespace MpiSchedule.Data;

public class PressScheduleContext(DbContextOptions<PressScheduleContext> options, ILogger<PressScheduleContext> logger) : DbContext(options)
{
    private static readonly string RowVersion = nameof(RowVersion);

    public DbSet<Press> Presses { get; set; } = default!;

    public DbSet<PressJob> Jobs { get; set; } = default!;

    public async Task<Press?> FindPress(int id, bool loadJobs = false)
    {
        if (loadJobs)
        {
            return await Presses.Include(p => p.Jobs).FirstOrDefaultAsync(p => p.PressId == id);
        }

        return await Presses.FindAsync(id);
    }

    public async Task<PressJob?> FindJob(int id, bool loadPress = false)
    {
        if (loadPress)
        {
            return await Jobs.Include(j => j.Press).FirstOrDefaultAsync(j => j.Id == id);
        }

        return await Jobs.FindAsync(id);
    }

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

        modelBuilder.Entity<Press>().Property<byte[]>(RowVersion).IsRowVersion();
        modelBuilder.Entity<Press>().HasIndex(p => p.PressId).IsUnique();

        modelBuilder.Entity<PressJob>().Property<byte[]>(RowVersion).IsRowVersion();
        modelBuilder.Entity<PressJob>().HasIndex(j => new { j.Id, j.JobNumber })
            .IsUnique();
        modelBuilder.Entity<PressJob>().Property(p => p.WipItemNumber).HasDefaultValue(string.Empty);
        modelBuilder.Entity<PressJob>().Property(p => p.FinishedItemNumber).HasDefaultValue(string.Empty);
        modelBuilder.Entity<PressJob>().Property(p => p.Notes).HasDefaultValue(string.Empty);

        base.OnModelCreating(modelBuilder);
    }
}