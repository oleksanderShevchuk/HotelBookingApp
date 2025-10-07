using HotelBooking.Application.DTOs.Booking;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Mappers;

public static class BookingMapper
{
    public static BookingDto ToDto(Booking b) =>
        new()
        {
            Id = b.Id,
            RoomId = b.RoomId,
            RoomNumber = b.Room?.Number,
            UserId = b.UserId,
            UserEmail = b.User?.Email,
            CheckInDate = b.CheckInDate,
            CheckOutDate = b.CheckOutDate,
            TotalPrice = b.TotalPrice
        };
}
