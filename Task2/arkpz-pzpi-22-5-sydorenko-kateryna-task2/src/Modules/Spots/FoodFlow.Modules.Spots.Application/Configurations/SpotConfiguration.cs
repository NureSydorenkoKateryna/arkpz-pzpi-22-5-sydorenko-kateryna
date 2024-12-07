using FoodFlow.Modules.Spots.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFlow.Modules.Spots.Application.Configurations;

public class SpotConfiguration : IEntityTypeConfiguration<Spot>
{
    public void Configure(EntityTypeBuilder<Spot> builder)
    {
        builder.ToTable("spots");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Type).IsRequired().HasMaxLength(100);

        builder.HasOne(x => x.Owner)
            .WithMany(x => x.Spots)
            .HasForeignKey(x => x.OwnerId)
            .IsRequired();

        builder.HasMany(c => c.ChildrenSpots)
            .WithOne(c => c.ParentSpot)
            .HasForeignKey(c => c.ParentSpotId);
    }
}
