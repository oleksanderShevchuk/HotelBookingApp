using HotelBooking.Application.Interfaces.Bookings;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _db;

    public BookingRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Booking booking, CancellationToken ct = default)
    {
        await _db.Bookings.AddAsync(booking, ct);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Booking booking, CancellationToken ct = default)
    {
        _db.Bookings.Remove(booking);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Booking>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.Bookings
            .Include(b => b.Room)
            .Include(b => b.User)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<Booking?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.Bookings
            .Include(b => b.Room)
            .Include(b => b.User)
            .FirstOrDefaultAsync(b => b.Id == id, ct);
    }

    public async Task<IEnumerable<Booking>> GetByUserIdAsync(Guid userId, CancellationToken ct = default)
    {
        return await _db.Bookings
            .Include(b => b.Room)
            .Include(b => b.User)
            .Where(b => b.UserId == userId)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task UpdateAsync(Booking booking, CancellationToken ct = default)
    {
        _db.Bookings.Update(booking);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<bool> IsRoomAvailable(Guid roomId, DateTime checkIn, DateTime checkOut, CancellationToken ct = default)
    {
        return !await _db.Bookings
            .AnyAsync(b =>
                b.RoomId == roomId &&
                (checkIn < b.CheckOutDate && checkOut > b.CheckInDate),
                ct);
    }
}
