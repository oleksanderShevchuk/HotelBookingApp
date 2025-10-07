using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Infrastructure.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
                .HasColumnType("binary(16)")
                .ValueGeneratedOnAdd();

        builder.Property(r => r.CreatedAt)
              .HasColumnType("datetime(6)")
              .ValueGeneratedOnAdd();

        builder.Property(r => r.UpdatedAt)
               .HasColumnType("datetime(6)");

        builder.Property(r => r.PricePerNight)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(r => r.Number)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(r => r.HotelId).HasColumnType("binary(16)");
        builder.Property(r => r.CategoryId).HasColumnType("binary(16)");

        builder.HasOne(r => r.Hotel)
            .WithMany(h => h.Rooms)
            .HasForeignKey(r => r.HotelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Category)
            .WithMany(c => c.Rooms)
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
