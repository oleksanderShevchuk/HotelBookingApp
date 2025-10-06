using HotelBooking.Application.Interfaces.Hotels;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly ApplicationDbContext _db;

    public HotelRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Hotel hotel, CancellationToken ct = default)
    {
        await _db.Hotels.AddAsync(hotel, ct);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Hotel hotel, CancellationToken ct = default)
    {
        _db.Hotels.Remove(hotel);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.Hotels.AnyAsync(h => h.Id == id, ct);
    }

    public async Task<IEnumerable<Hotel>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.Hotels
            .AsNoTracking()
            .OrderBy(h => h.Name)
            .ToListAsync(ct);
    }

    public async Task<Hotel?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.Hotels
            .AsNoTracking()
            .FirstOrDefaultAsync(h => h.Id == id, ct);
    }

    public async Task<(IEnumerable<Hotel> Items, int Total)> SearchAsync(string? city, int page, int pageSize, CancellationToken ct = default)
    {
        var query = _db.Hotels.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(city))
            query = query.Where(h => h.City.Contains(city));

        var total = await query.CountAsync(ct);
        var items = await query
            .OrderBy(h => h.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

        return (items, total);
    }

    public async Task UpdateAsync(Hotel hotel, CancellationToken ct = default)
    {
        _db.Hotels.Update(hotel);
        await _db.SaveChangesAsync(ct);
    }
}
