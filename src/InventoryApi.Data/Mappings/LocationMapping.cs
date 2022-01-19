using InventoryApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryApi.Data.Mappings
{
    public class LocationMapping : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Address)
                .IsRequired()
                .HasColumnType("varchar(300)");

            // 1 : N => Location : Products
            builder.HasMany(f => f.Products)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);

            builder.ToTable("Location");
        }
    }
}