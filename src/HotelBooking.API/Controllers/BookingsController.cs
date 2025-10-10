using System.Security.Claims;
using HotelBooking.Application.DTOs.Booking;
using HotelBooking.Application.Interfaces.Bookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _service;

    public BookingsController(IBookingService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var bookings = await _service.GetAllAsync();
        return Ok(bookings);
    }

    [HttpGet("my")]
    [Authorize(Roles = "Client,Admin")]
    public async Task<IActionResult> GetMyBookings()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var bookings = await _service.GetUserBookingsAsync(userId);
        return Ok(bookings);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Client,Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var booking = await _service.GetByIdAsync(id);
        if (booking == null) return NotFound();
        return Ok(booking);
    }

    [HttpPost]
    [Authorize(Roles = "Client,Admin")]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto dto)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var (success, message) = await _service.CreateAsync(userId, dto);
        if (!success) return BadRequest(message);
        return Ok(message);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Client,Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var isAdmin = User.IsInRole("Admin");

        var deleted = await _service.DeleteAsync(id, userId, isAdmin);
        if (!deleted) return Forbid();
        return NoContent();
    }
}
