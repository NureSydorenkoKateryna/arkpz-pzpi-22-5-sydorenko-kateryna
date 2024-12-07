using FoodFlow.Modules.Culinary.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFlow.Modules.Culinary.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(250);

        builder.HasMany(x => x.Ingredients)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(x => x.Restaurant)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.RestaurantId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
