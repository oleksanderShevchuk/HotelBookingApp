using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HotelBooking.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsEmailConfirmed { get; set; } = false;
    public ICollection<Booking>? Bookings { get; set; }
}
