using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Application.DTOs.Hotel
{
    public class CreateHotelDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = default!;

        [Required]
        [MaxLength(300)]
        public string Address { get; set; } = default!;

        public string Description { get; set; } = string.Empty;
    }
}
