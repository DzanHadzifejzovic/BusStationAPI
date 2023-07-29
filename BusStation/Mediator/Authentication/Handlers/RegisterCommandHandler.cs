using AutoMapper;
using BusinessLogic.Interfaces;
using BusStation.Mediator.Authentication.Queries;
using Data.Models;
using Mappings.DTOs.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BusStation.Mediator.Authentication.Handlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, LoginAndRegisterReturnModel>
    {

        private readonly UserManager<BaseUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public RegisterCommandHandler(UserManager<BaseUser> userManager, RoleManager<IdentityRole> roleManager,
            IMapper mapper, IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _authenticationService = authenticationService;
            _configuration = configuration;
        }
        public async Task<LoginAndRegisterReturnModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(request.model.Email);

            if (userExists != null)
                throw new Exception("User already exist");

            BaseUser user = _mapper.Map<BaseUser>(request.model);

            var result = await _userManager.CreateAsync(user, request.model.Password);


            if (await _roleManager.RoleExistsAsync("Buyer"))
            {
                await _userManager.AddToRoleAsync(user, "Buyer");
            }

            if (!result.Succeeded)
                throw new Exception("User creation failed! Please check user details and try again.");

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = _authenticationService.GenerateToken(authClaims);

            var refreshToken = _authenticationService.GenerateRefreshToken();

            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInDays);

            await _userManager.UpdateAsync(user);


            return new LoginAndRegisterReturnModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                Expires = token.ValidTo,
                Roles = userRoles.ToList()

            };
        }
    }
}
