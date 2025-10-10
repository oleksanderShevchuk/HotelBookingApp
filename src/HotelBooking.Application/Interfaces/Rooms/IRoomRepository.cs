using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces.Rooms
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync(Guid? hotelId = null, CancellationToken ct = default);
        Task<Room?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task AddAsync(Room room, CancellationToken ct = default);
        Task UpdateAsync(Room room, CancellationToken ct = default);
        Task DeleteAsync(Room room, CancellationToken ct = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<RoomCategory>> GetAllRoomCategoriesAsync(CancellationToken ct);
    }
}
