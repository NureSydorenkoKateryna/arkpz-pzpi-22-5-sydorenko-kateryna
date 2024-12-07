using FoodFlow.Modules.Culinary.Core.Entities;
using FoodFlow.Modules.Culinary.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFlow.Modules.Culinary.Persistence.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("ingredients");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Amount).IsRequired();

        builder.Property(x => x.Unit)
            .IsRequired()
            .HasConversion(x => x.Unit, x => new MeasurementUnit(x));

        builder.HasOne(x => x.TechCard)
            .WithMany(x => x.Ingredients)
            .HasForeignKey(x => x.TechCardId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Ingredients)
            .HasForeignKey(x => x.ProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}
