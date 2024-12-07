using Microsoft.EntityFrameworkCore;
using FoodFlow.Modules.Spots.Application.Domain.Entities;
using FoodFlow.Modules.Spots.Application.Configurations;

namespace FoodFlow.Modules.Spots.Application;

public class SpotsDbContext : DbContext
{
    public DbSet<Spot> Spots { get; set; }
    public DbSet<Owner> Owners { get; set; }

    public SpotsDbContext(DbContextOptions<SpotsDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("spots");

        modelBuilder.ApplyConfiguration(new SpotConfiguration());
        modelBuilder.ApplyConfiguration(new OwnerConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
