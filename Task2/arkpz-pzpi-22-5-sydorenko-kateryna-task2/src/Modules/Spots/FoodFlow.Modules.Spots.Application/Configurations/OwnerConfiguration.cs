using FoodFlow.Modules.Spots.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFlow.Modules.Spots.Application.Configurations;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable("owners");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Email).IsRequired();

        builder.HasMany(x => x.Spots)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId);
    }
}
