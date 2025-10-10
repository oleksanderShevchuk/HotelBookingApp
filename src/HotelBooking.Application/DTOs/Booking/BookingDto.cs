namespace HotelBooking.Application.DTOs.Booking
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid? RoomId { get; set; }
        public string? RoomNumber { get; set; }
        public Guid? UserId { get; set; }
        public string? UserEmail { get; set; }
        public Guid? HotelId { get; set; }
        public string? HotelName { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
