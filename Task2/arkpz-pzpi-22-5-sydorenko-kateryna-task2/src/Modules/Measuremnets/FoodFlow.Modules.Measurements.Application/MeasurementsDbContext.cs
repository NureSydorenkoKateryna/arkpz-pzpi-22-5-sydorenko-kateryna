using FoodFlow.Modules.Measurements.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodFlow.Modules.Measurements.Application;

public class MeasurementsDbContext : DbContext
{
    public DbSet<Measurement> Measurements { get; set; }
    public MeasurementsDbContext(DbContextOptions<MeasurementsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("measurements");

        modelBuilder.Entity<Measurement>().ToTable("measurements");
        modelBuilder.Entity<Measurement>().HasKey(x => x.Id);
        modelBuilder.Entity<Measurement>().Property(x => x.Token).IsRequired();
        modelBuilder.Entity<Measurement>().Property(x => x.Value).IsRequired();
    }
}
