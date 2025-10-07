using HotelBooking.Application.DTOs.Room;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Mappers;

public static class RoomMapper
{
    public static RoomDto ToDto(Room room) =>
        new()
        {
            Id = room.Id,
            Number = room.Number,
            Capacity = room.Capacity,
            PricePerNight = room.PricePerNight,
            HotelId = room.HotelId,
            HotelName = room.Hotel?.Name,
            RoomCategoryId = room.CategoryId,
            RoomCategoryName = room.Category?.Name
        };
}
