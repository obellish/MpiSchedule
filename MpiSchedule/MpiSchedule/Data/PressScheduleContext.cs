using Microsoft.EntityFrameworkCore;

namespace MpiSchedule.Data;

public class PressScheduleContext(DbContextOptions<PressScheduleContext> options) : DbContext(options)
{
    public DbSet<Press> Presses { get; set; }

    public DbSet<PressJob> Jobs { get; set; }

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