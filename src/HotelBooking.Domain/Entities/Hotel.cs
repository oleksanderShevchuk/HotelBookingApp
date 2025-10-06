using HotelBooking.Domain.Common;

namespace HotelBooking.Domain.Entities;

public class Hotel : BaseEntity
{
    public string Name { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Description { get; set; } = default!;

    public ICollection<Room>? Rooms { get; set; }
}
