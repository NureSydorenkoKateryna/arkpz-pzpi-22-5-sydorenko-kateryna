using Microsoft.EntityFrameworkCore;
using FoodFlow.Modules.Culinary.Core.Entities;

namespace FoodFlow.Modules.Culinary.Persistence;

public class CulinaryDbContext : DbContext
{
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<TechCard> TechCards { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RestaurantTechCard> RestaurantTechCards { get; set; }

    public CulinaryDbContext(DbContextOptions<CulinaryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("culinary");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CulinaryDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
