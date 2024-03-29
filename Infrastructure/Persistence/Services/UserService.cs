
using BusStation_API.Core.Domain.Entities;
using BusStation_API.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusStation_API.Infrastructure.Persistance.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public UserService(UserManager<BaseUser> userManager,IUnitOfWork unitOfWork,IConfiguration configuration)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<List<BaseUser>> GetWorkers()
        {
            var list = await _userManager.Users.ToListAsync();
            return list;
        }

        public async Task<BaseUser?> GetWorkerById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user==null)
                return null;

            return user;
        }
        public async Task<bool> DeleteUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user==null)
                return false;

            try
            {
                await _userManager.DeleteAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<string> GetRolesFromUser(string token)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                SecurityToken validatedToken;
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

                var userRole = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                //_userManager.GetRolesAsync();
                return userRole;
            }
            catch
            {
                return "Invalid token";
            }
        } 
        public async Task<string> DeleteAllRefreshTokenForUserById(string userId)
        {
            var user = await GetWorkerById(userId);
            try
            {
                user.RefreshToken = null;
                user.RefreshTokenExpiryTime = DateTime.UtcNow;

                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                return "Not successfully logout";
            }
            return "Success logout";
        }      
    }
}
