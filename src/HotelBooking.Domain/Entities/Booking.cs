using HotelBooking.Domain.Common;
using HotelBooking.Infrastructure.Identity;

namespace HotelBooking.Domain.Entities;

public class Booking : BaseEntity
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = default!;

    public Guid RoomId { get; set; }
    public Room Room { get; set; } = default!;

    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

    public decimal TotalPrice { get; set; }
}
