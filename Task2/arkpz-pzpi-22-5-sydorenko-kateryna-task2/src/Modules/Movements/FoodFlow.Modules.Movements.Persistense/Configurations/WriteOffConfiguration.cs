using FoodFlow.Modules.Movements.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFlow.Modules.Movements.Persistence.Configurations;

public class WriteOffConfiguration : IEntityTypeConfiguration<WriteOff>
{
    public void Configure(EntityTypeBuilder<WriteOff> builder)
    {
        builder.ToTable("write_offs");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasOne(x => x.Warehouse)
            .WithMany(x => x.WriteOffs)
            .HasForeignKey(x => x.WarehouseId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}
