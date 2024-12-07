using FoodFlow.Modules.Movements.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFlow.Modules.Movements.Persistence.Configurations;

public class RestConfiguration : IEntityTypeConfiguration<Rest>
{
    public void Configure(EntityTypeBuilder<Rest> builder)
    {
        builder.ToTable("rests");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasOne(x => x.Warehouse)
            .WithMany(x => x.Rests)
            .HasForeignKey(x => x.WarehouseId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}
