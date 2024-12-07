using FoodFlow.Modules.Movements.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodFlow.Modules.Movements.Persistence;

public class MovementsDbContext : DbContext
{
    public DbSet<WriteOff> WriteOffs { get; set; }
    public DbSet<Import> Imports { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Rest> Rests { get; set; }
    public DbSet<ImportItem> ImportItems { get; set; }

    public MovementsDbContext(DbContextOptions<MovementsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("movements");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovementsDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
