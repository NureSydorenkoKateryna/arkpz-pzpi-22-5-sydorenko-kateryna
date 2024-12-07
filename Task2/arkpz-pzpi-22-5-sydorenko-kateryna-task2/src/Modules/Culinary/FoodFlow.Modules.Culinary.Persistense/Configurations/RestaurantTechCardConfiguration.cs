using FoodFlow.Modules.Culinary.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFlow.Modules.Culinary.Persistence.Configurations;

public class RestaurantTechCardConfiguration : IEntityTypeConfiguration<RestaurantTechCard>
{
    public void Configure(EntityTypeBuilder<RestaurantTechCard> builder)
    {
        builder.ToTable("restaurant_tech_cards");

        builder.HasKey(rt => new { rt.RestaurantId, rt.TechCardId });

        builder.HasOne(rt => rt.Restaurant)
            .WithMany(r => r.RestaurantTechCards)
            .HasForeignKey(rt => rt.RestaurantId);

        builder.HasOne(rt => rt.TechCard)
            .WithMany(tc => tc.RestaurantTechCards)
            .HasForeignKey(rt => rt.TechCardId);
    }
}
