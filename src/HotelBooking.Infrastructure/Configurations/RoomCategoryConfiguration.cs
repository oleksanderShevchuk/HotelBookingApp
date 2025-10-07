using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Infrastructure.Configurations;

public class RoomCategoryConfiguration : IEntityTypeConfiguration<RoomCategory>
{
    public void Configure(EntityTypeBuilder<RoomCategory> builder)
    {
        builder.HasKey(rc => rc.Id);

        builder.Property(rc => rc.Id)
                 .HasColumnType("binary(16)")
                 .ValueGeneratedOnAdd();

        builder.Property(rc => rc.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(rc => rc.CreatedAt)
              .HasColumnType("datetime(6)")
              .ValueGeneratedOnAdd();

        builder.Property(rc => rc.UpdatedAt)
               .HasColumnType("datetime(6)");

        builder.HasData(
            new RoomCategory { Id = SeedGuids.StandardRoomCategoryId, Name = "Standard", CreatedAt = new DateTime(2025, 10, 07, 0, 0, 0, DateTimeKind.Utc) },
            new RoomCategory { Id = SeedGuids.DeluxeRoomCategoryId, Name = "Deluxe", CreatedAt = new DateTime(2025, 10, 07, 0, 0, 0, DateTimeKind.Utc) },
            new RoomCategory { Id = SeedGuids.SuiteRoomCategoryId, Name = "Suite", CreatedAt = new DateTime(2025, 10, 07, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}
