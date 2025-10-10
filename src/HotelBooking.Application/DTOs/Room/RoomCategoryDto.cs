namespace HotelBooking.Application.DTOs.Room
{
    public class RoomCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
