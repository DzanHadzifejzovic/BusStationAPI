using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BusStation_API.Core.Domain.Interfaces
{
    public interface IAuthenticationService //<TToken,TClaim,TPrincipal>
    {
        JwtSecurityToken GenerateToken(List<Claim> authClaims);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
