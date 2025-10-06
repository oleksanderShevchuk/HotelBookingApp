using HotelBooking.Infrastructure.Data;
using HotelBooking.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.Property(r => r.Description)
           .HasMaxLength(200);

        builder.HasData(
           new ApplicationRole
           {
               Id = SeedGuids.AdminRoleId,
               Name = "Admin",
               NormalizedName = "ADMIN",
               Description = "Full access to manage hotels, rooms, and bookings"
           },
           new ApplicationRole
           {
               Id = SeedGuids.ClientRoleId,
               Name = "Client",
               NormalizedName = "CLIENT",
               Description = "Can browse hotels and make bookings"
           }
       );
    }
}
