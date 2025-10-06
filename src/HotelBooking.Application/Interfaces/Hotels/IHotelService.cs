using HotelBooking.Application.DTOs.Hotel;

namespace HotelBooking.Application.Interfaces.Hotels
{
    public interface IHotelService
    {
        Task<HotelDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<HotelDto>> GetAllAsync(CancellationToken ct = default);
        Task<(IEnumerable<HotelDto> Items, int Total)> SearchAsync(string? city, int page, int pageSize, CancellationToken ct = default);
        Task<HotelDto> CreateAsync(CreateHotelDto dto, CancellationToken ct = default);
        Task<bool> UpdateAsync(Guid id, UpdateHotelDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
