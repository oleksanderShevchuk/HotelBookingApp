using System.Data;
using HotelBooking.Domain.Common;

namespace HotelBooking.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;

    public Guid RoleId { get; set; }
    public UserRole Role { get; set; } = default!;

    public ICollection<Booking>? Bookings { get; set; }
}
