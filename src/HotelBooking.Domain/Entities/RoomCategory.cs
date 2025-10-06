using HotelBooking.Domain.Common;

namespace HotelBooking.Domain.Entities;

public class RoomCategory : BaseEntity
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }

    public ICollection<Room>? Rooms { get; set; }
}
