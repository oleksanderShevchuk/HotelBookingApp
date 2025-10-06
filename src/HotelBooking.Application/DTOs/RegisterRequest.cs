namespace HotelBooking.Application.DTOs
{
    public class RegisterRequest
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public string Role { get; set; } = "Client"; // by default
    }
}
