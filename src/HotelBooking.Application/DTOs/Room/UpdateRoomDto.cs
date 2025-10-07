namespace HotelBooking.Application.DTOs.Room
{
    public class UpdateRoomDto
    {
        public string Number { get; set; } = default!;
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public Guid RoomCategoryId { get; set; }
    }
}
