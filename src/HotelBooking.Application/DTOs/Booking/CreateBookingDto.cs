namespace HotelBooking.Application.DTOs.Booking
{
    public class CreateBookingDto
    {
        public Guid RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
