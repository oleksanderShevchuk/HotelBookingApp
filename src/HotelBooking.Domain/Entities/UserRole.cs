using HotelBooking.Domain.Common;

namespace HotelBooking.Domain.Entities;

public class UserRole : BaseEntity
{
    public string Name { get; set; } = default!;

    public ICollection<User>? Users { get; set; }
}
