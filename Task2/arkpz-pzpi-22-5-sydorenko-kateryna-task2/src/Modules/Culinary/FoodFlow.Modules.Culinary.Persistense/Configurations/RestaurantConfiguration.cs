using FoodFlow.Modules.Culinary.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFlow.Modules.Culinary.Persistence.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.ToTable("restaurants");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.SpotId).IsRequired();
        builder.Property(x => x.OwnerId).IsRequired();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

        builder.HasMany(x => x.RestaurantTechCards)
            .WithOne(x => x.Restaurant)
            .HasForeignKey(x => x.RestaurantId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
