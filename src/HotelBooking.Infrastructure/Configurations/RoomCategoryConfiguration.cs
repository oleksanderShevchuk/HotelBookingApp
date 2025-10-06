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

        builder.Property(rc => rc.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(
            new RoomCategory { Id = SeedGuids.StandardRoomCategoryId, Name = "Standard" },
            new RoomCategory { Id = SeedGuids.DeluxeRoomCategoryId, Name = "Deluxe" },
            new RoomCategory { Id = SeedGuids.SuiteRoomCategoryId, Name = "Suite" }
        );
    }
}
