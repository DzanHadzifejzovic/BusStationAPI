using BusinessLogic.Interfaces;
using BusStation.Mediator.Authentication.Commands;
using Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace BusStation.Mediator.Authentication.Handlers
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenModel>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<BaseUser> _userManager;

        public RefreshTokenCommandHandler(IAuthenticationService authenticationService,UserManager<BaseUser> userManager)
        {
            _authenticationService = authenticationService;
            _userManager = userManager;
        }
        public async Task<TokenModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            if (request.tokenModel is null)
            {
                throw new Exception("Invalid client request");
            }
            string? accessToken = request.tokenModel.AccessToken;

            var principal = _authenticationService.GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                throw new Exception("Invalid access token or refresh token");
            }

            string username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null  || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new Exception("Invalid access token or refresh token");
            }

            var newAccessToken = _authenticationService.GenerateToken(principal.Claims.ToList());

            TokenModel tokenModel = new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken)
            };

            return tokenModel;
        }
    }
}
