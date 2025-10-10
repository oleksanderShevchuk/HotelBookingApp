using HotelBooking.Application.Interfaces.Rooms;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly ApplicationDbContext _db;

    public RoomRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Room room, CancellationToken ct = default)
    {
        await _db.Rooms.AddAsync(room, ct);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Room room, CancellationToken ct = default)
    {
        _db.Rooms.Remove(room);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.Rooms.AnyAsync(r => r.Id == id, ct);
    }

    public async Task<IEnumerable<Room>> GetAllAsync(Guid? hotelId = null, CancellationToken ct = default)
    {
        var query = _db.Rooms
            .Include(r => r.Hotel)
            .Include(r => r.Category)
            .AsNoTracking()
            .AsQueryable();

        if (hotelId.HasValue)
            query = query.Where(r => r.HotelId == hotelId);

        return await query.ToListAsync(ct);
    }

    public async Task<Room?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.Rooms
            .Include(r => r.Hotel)
            .Include(r => r.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id, ct);
    }

    public async Task UpdateAsync(Room room, CancellationToken ct = default)
    {
        _db.Rooms.Update(room);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<RoomCategory>> GetAllRoomCategoriesAsync(CancellationToken ct = default)
    {
        return await _db.RoomCategories
            .AsNoTracking()
            .AsQueryable()
            .ToListAsync(ct);
    }
}
