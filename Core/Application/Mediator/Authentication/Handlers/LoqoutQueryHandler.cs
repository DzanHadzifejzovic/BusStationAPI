using Mediator.Authentication.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using BusStation_API.Core.Domain.Interfaces;
using BusStation_API.Core.Domain.Entities;

namespace BusStation.Mediator.Authentication.Handlers
{
    public class LoqoutQueryHandler : IRequestHandler<LogoutQuery, string>
    {
        private readonly IUserService _userService;
        private readonly SignInManager<BaseUser> _signInManager;

        public LoqoutQueryHandler(IUserService authenticationService, SignInManager<BaseUser> signInManager)
        {
            _userService = authenticationService;
            _signInManager = signInManager;
        }
        public async Task<string> Handle(LogoutQuery request, CancellationToken cancellationToken)
        {
            var isSuccess = "";
             try
             {
                await _signInManager.SignOutAsync();
                isSuccess = await _userService.DeleteAllRefreshTokenForUserById(request.userId);
             }
             catch (Exception ex)
             {
                 return isSuccess;
             }
            return isSuccess;
        }
    }
}
