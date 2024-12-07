using FoodFlow.Modules.Culinary.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFlow.Modules.Culinary.Persistence.Configurations;

public class TechCardConfiguration : IEntityTypeConfiguration<TechCard>
{
    public void Configure(EntityTypeBuilder<TechCard> builder)
    {
        builder.ToTable("techcards");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Description);

        builder.HasMany(x => x.Ingredients)
            .WithOne(x => x.TechCard)
            .HasForeignKey(x => x.TechCardId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.RestaurantTechCards)
            .WithOne(x => x.TechCard)
            .HasForeignKey(x => x.TechCardId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
