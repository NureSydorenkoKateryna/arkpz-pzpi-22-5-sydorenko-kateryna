using FoodFlow.Modules.Movements.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFlow.Modules.Movements.Persistence.Configurations;

public class ImportConfiguration : IEntityTypeConfiguration<Import>
{
    public void Configure(EntityTypeBuilder<Import> builder)
    {
        builder.ToTable("imports");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.TimePoint).IsRequired();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

        builder.HasOne(x => x.Warehouse)
            .WithMany(x => x.Imports)
            .HasForeignKey(x => x.WarehouseId)
            .IsRequired()
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Import)
            .HasForeignKey(x => x.ImportId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
