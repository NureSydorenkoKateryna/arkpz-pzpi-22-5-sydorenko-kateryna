using FoodFlow.Modules.Users.Application.Configurations;
using FoodFlow.Modules.Users.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodFlow.Modules.Users.Application;

public class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UsersDbContext(DbContextOptions<UsersDbContext> options) 
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
