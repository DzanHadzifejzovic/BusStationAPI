﻿using Microsoft.AspNetCore.Identity;

namespace BusStation_API.Core.Domain.Entities
{
    public class BaseUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<BusLineUser> BusLineUsers { get; set; }
    }
}
