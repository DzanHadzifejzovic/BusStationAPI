namespace BusStation_API.Core.Application.DTOs.Authentication
{
    public class LoginAndRegisterReturnModel
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string? RefreshToken { get; set; }
        public List<string> Roles { get; set; }
    }
}
