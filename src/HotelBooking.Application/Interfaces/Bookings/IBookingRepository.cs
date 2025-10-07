using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces.Bookings
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllAsync(CancellationToken ct = default);
        Task<IEnumerable<Booking>> GetByUserIdAsync(Guid userId, CancellationToken ct = default);
        Task<Booking?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task AddAsync(Booking booking, CancellationToken ct = default);
        Task UpdateAsync(Booking booking, CancellationToken ct = default);
        Task DeleteAsync(Booking booking, CancellationToken ct = default);
        Task<bool> IsRoomAvailable(Guid roomId, DateTime checkIn, DateTime checkOut, CancellationToken ct = default);
    }
}
