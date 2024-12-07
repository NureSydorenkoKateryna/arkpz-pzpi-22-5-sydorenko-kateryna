using FoodFlow.Modules.Movements.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFlow.Modules.Movements.Persistence.Configurations;

public class ImportItemConfiguration : IEntityTypeConfiguration<ImportItem>
{
    public void Configure(EntityTypeBuilder<ImportItem> builder)
    {
        builder.ToTable("importitems");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.TotalPrice).IsRequired();

        builder.HasOne(x => x.Import)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.ImportId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
