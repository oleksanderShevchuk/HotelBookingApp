using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces.Hotels
{
    public interface IHotelRepository
    {
        Task<Hotel?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<Hotel>> GetAllAsync(CancellationToken ct = default);
        Task<(IEnumerable<Hotel> Items, int Total)> SearchAsync(string? city, int page, int pageSize, CancellationToken ct = default);
        Task AddAsync(Hotel hotel, CancellationToken ct = default);
        Task UpdateAsync(Hotel hotel, CancellationToken ct = default);
        Task DeleteAsync(Hotel hotel, CancellationToken ct = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);
    }
}
