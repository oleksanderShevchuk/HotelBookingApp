using HotelBooking.Application.DTOs.Hotel;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Mappers;

public static class HotelMapper
{
    public static HotelDto ToDto(Hotel h) =>
        new()
        {
            Id = h.Id,
            Name = h.Name,
            City = h.City,
            Address = h.Address,
            Description = h.Description,
            CreatedAt = h.CreatedAt
        };

    public static Hotel ToEntity(CreateHotelDto dto) =>
        new()
        {
            Name = dto.Name,
            City = dto.City,
            Address = dto.Address,
            Description = dto.Description
        };

    public static void MapToEntity(UpdateHotelDto dto, Hotel entity)
    {
        entity.Name = dto.Name;
        entity.City = dto.City;
        entity.Address = dto.Address;
        entity.Description = dto.Description;
    }
}
