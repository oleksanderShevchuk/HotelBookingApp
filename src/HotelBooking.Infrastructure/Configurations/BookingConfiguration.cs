using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Infrastructure.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
                .HasColumnType("binary(16)")
                .ValueGeneratedOnAdd();

        builder.Property(b => b.CreatedAt)
               .HasColumnType("datetime(6)")
               .ValueGeneratedOnAdd();

        builder.Property(b => b.UpdatedAt)
               .HasColumnType("datetime(6)");

        builder.Property(b => b.CheckInDate)
               .HasColumnType("datetime(6)");

        builder.Property(b => b.CheckOutDate)
               .HasColumnType("datetime(6)");

        builder.Property(b => b.TotalPrice)
            .HasPrecision(10, 2);

        builder.Property(b => b.UserId).HasColumnType("binary(16)");
        builder.Property(b => b.RoomId).HasColumnType("binary(16)");

        builder.HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(b => b.Room)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}