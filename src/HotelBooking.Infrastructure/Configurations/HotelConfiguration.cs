using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Infrastructure.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
                 .HasColumnType("binary(16)")
                 .ValueGeneratedOnAdd();

        builder.Property(h => h.CreatedAt)
               .HasColumnType("datetime(6)")
               .ValueGeneratedOnAdd();

        builder.Property(h => h.UpdatedAt)
               .HasColumnType("datetime(6)");

        builder.Property(h => h.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(h => h.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(h => h.Address)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(h => h.Description)
           .HasMaxLength(2000);
    }
}
