﻿namespace BusStation_API.Core.Domain.Entities
{
    public class TokenModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}