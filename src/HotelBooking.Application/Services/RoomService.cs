using HotelBooking.Application.DTOs.Room;
using HotelBooking.Application.Interfaces.Rooms;
using HotelBooking.Application.Mappers;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _repo;

    public RoomService(IRoomRepository repo)
    {
        _repo = repo;
    }

    public async Task<RoomDto> CreateAsync(CreateRoomDto dto, CancellationToken ct = default)
    {
        var entity = new Room
        {
            Number = dto.Number,
            Capacity = dto.Capacity,
            PricePerNight = dto.PricePerNight,
            HotelId = dto.HotelId,
            CategoryId = dto.RoomCategoryId
        };

        await _repo.AddAsync(entity, ct);
        return RoomMapper.ToDto(entity);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        if (entity == null) return false;
        await _repo.DeleteAsync(entity, ct);
        return true;
    }

    public async Task<IEnumerable<RoomDto>> GetAllAsync(Guid? hotelId = null, CancellationToken ct = default)
    {
        var rooms = await _repo.GetAllAsync(hotelId, ct);
        return rooms.Select(RoomMapper.ToDto);
    }

    public async Task<RoomDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var room = await _repo.GetByIdAsync(id, ct);
        return room == null ? null : RoomMapper.ToDto(room);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateRoomDto dto, CancellationToken ct = default)
    {
        var room = await _repo.GetByIdAsync(id, ct);
        if (room == null) return false;

        room.Number = dto.Number;
        room.Capacity = dto.Capacity;
        room.PricePerNight = dto.PricePerNight;
        room.CategoryId = dto.RoomCategoryId;
        room.UpdatedAt = DateTime.UtcNow;

        await _repo.UpdateAsync(room, ct);
        return true;
    }

    public async Task<IEnumerable<RoomCategoryDto>> GetAllRoomCategoriesAsync(CancellationToken ct = default)
    {
        var rc = await _repo.GetAllRoomCategoriesAsync(ct);
        return rc.Select(RoomMapper.ToCatagoryDto);
    }
}
