using HotelBooking.Application.DTOs.Booking;

namespace HotelBooking.Application.Interfaces.Bookings
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllAsync(CancellationToken ct = default);
        Task<IEnumerable<BookingDto>> GetUserBookingsAsync(Guid userId, CancellationToken ct = default);
        Task<BookingDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<(bool Success, string Message)> CreateAsync(Guid userId, CreateBookingDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(Guid id, Guid userId, bool isAdmin, CancellationToken ct = default);
    }
}
