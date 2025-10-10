using HotelBooking.Application.DTOs.Room;

namespace HotelBooking.Application.Interfaces.Rooms
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllAsync(Guid? hotelId = null, CancellationToken ct = default);
        Task<RoomDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<RoomDto> CreateAsync(CreateRoomDto dto, CancellationToken ct = default);
        Task<bool> UpdateAsync(Guid id, UpdateRoomDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<RoomCategoryDto>> GetAllRoomCategoriesAsync(CancellationToken ct = default);
    }
}
