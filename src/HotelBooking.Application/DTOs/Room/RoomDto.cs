namespace HotelBooking.Application.DTOs.Room
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = default!;
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }

        public Guid HotelId { get; set; }
        public string? HotelName { get; set; }

        public Guid RoomCategoryId { get; set; }
        public string? RoomCategoryName { get; set; }
    }
}
