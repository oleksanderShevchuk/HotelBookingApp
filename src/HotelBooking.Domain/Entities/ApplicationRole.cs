﻿using Microsoft.AspNetCore.Identity;

namespace HotelBooking.Infrastructure.Identity;

public class ApplicationRole : IdentityRole<Guid>
{
    public string? Description { get; set; }
}
