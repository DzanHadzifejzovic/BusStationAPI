﻿using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.Authentication.Queries;
using Data.Models;
using Mappings.DTOs.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BusStation.Mediator.Authentication.Handlers
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginAndRegisterReturnModel>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        private readonly UserManager<BaseUser> _userManager;
        private readonly IConfiguration _configuration;

        public LoginQueryHandler(IMapper mapper, IAuthenticationService authenticationService,
            UserManager<BaseUser> userManager,IConfiguration configuration)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<LoginAndRegisterReturnModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.model.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user,request.model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim("id",user.Id.ToString()),
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
            throw new Exception("User login failed! Please check user details and try again.");
        }

    }
}
