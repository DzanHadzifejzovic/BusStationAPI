using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace BusinessLogic.Interfaces
{
    public interface IAuthenticationService
    {
        JwtSecurityToken GenerateToken(List<Claim> authClaims);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
