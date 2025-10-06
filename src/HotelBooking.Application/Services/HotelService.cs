using HotelBooking.Application.DTOs.Hotel;
using HotelBooking.Application.Interfaces.Hotels;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Services;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _repo;
    public HotelService(IHotelRepository repo)
    {
        _repo = repo;
    }

    public async Task<HotelDto> CreateAsync(CreateHotelDto dto, CancellationToken ct = default)
    {
        var entity = new Hotel
        {
            Name = dto.Name,
            City = dto.City,
            Address = dto.Address,
            Description = dto.Description,
        };

        await _repo.AddAsync(entity, ct);
        return Mappers.HotelMapper.ToDto(entity);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        if (entity == null) return false;

        await _repo.DeleteAsync(entity, ct);
        return true;
    }

    public async Task<IEnumerable<HotelDto>> GetAllAsync(CancellationToken ct = default)
    {
        var list = await _repo.GetAllAsync(ct);
        return list.Select(Mappers.HotelMapper.ToDto);
    }

    public async Task<HotelDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        return entity == null ? null : Mappers.HotelMapper.ToDto(entity);
    }

    public async Task<(IEnumerable<HotelDto> Items, int Total)> SearchAsync(string? city, int page, int pageSize, CancellationToken ct = default)
    {
        var (items, total) = await _repo.SearchAsync(city, page, pageSize, ct);
        return (items.Select(Mappers.HotelMapper.ToDto), total);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateHotelDto dto, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        if (entity == null) return false;

        entity.Name = dto.Name;
        entity.City = dto.City;
        entity.Address = dto.Address;
        entity.Description = dto.Description;
        entity.UpdatedAt = DateTime.UtcNow;

        await _repo.UpdateAsync(entity, ct);
        return true;
    }
}
