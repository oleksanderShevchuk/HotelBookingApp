namespace HotelBooking.Application.DTOs.Hotel
{
    public class UpdateHotelDto
    {
        public string Name { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Description { get; set; } = string.Empty;
    }
}
