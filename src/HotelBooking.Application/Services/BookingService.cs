using HotelBooking.Application.DTOs.Booking;
using HotelBooking.Application.Interfaces.Bookings;
using HotelBooking.Application.Interfaces.Rooms;
using HotelBooking.Application.Mappers;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _repo;
    private readonly IRoomRepository _roomRepo;

    public BookingService(IBookingRepository repo, IRoomRepository roomRepo)
    {
        _repo = repo;
        _roomRepo = roomRepo;
    }

    public async Task<IEnumerable<BookingDto>> GetAllAsync(CancellationToken ct = default)
    {
        var list = await _repo.GetAllAsync(ct);
        return list.Select(BookingMapper.ToDto);
    }

    public async Task<BookingDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var booking = await _repo.GetByIdAsync(id, ct);
        return booking == null ? null : BookingMapper.ToDto(booking);
    }

    public async Task<IEnumerable<BookingDto>> GetUserBookingsAsync(Guid userId, CancellationToken ct = default)
    {
        var list = await _repo.GetByUserIdAsync(userId, ct);
        return list.Select(BookingMapper.ToDto);
    }

    public async Task<(bool Success, string Message)> CreateAsync(Guid userId, CreateBookingDto dto, CancellationToken ct = default)
    {
        if (dto.CheckInDate >= dto.CheckOutDate)
            return (false, "Check-out date must be later than check-in date.");

        var room = await _roomRepo.GetByIdAsync(dto.RoomId, ct);
        if (room == null)
            return (false, "Room not found.");

        var available = await _repo.IsRoomAvailable(dto.RoomId, dto.CheckInDate, dto.CheckOutDate, ct);
        if (!available)
            return (false, "Room is not available for selected dates.");

        var totalDays = (dto.CheckOutDate - dto.CheckInDate).Days;
        var totalPrice = totalDays * room.PricePerNight;

        var booking = new Booking
        {
            UserId = userId,
            RoomId = dto.RoomId,
            CheckInDate = dto.CheckInDate,
            CheckOutDate = dto.CheckOutDate,
            TotalPrice = totalPrice
        };

        await _repo.AddAsync(booking, ct);
        return (true, "Booking created successfully.");
    }

    public async Task<bool> DeleteAsync(Guid id, Guid userId, bool isAdmin, CancellationToken ct = default)
    {
        var booking = await _repo.GetByIdAsync(id, ct);
        if (booking == null) return false;

        if (!isAdmin && booking.UserId != userId)
            return false; // user can not delete other's booking

        await _repo.DeleteAsync(booking, ct);
        return true;
    }
}
