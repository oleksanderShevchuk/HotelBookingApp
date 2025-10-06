using HotelBooking.Domain.Common;

namespace HotelBooking.Domain.Entities;

public class Room : BaseEntity
{
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; } = default!;

    public Guid CategoryId { get; set; }
    public RoomCategory Category { get; set; } = default!;

    public decimal PricePerNight { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; } = true;

    public ICollection<Booking>? Bookings { get; set; }
}
