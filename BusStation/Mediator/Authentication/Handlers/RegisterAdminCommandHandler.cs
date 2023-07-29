using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.Authentication.Queries;
using Data.Models;
using Mappings.DTOs.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BusStation.Mediator.Authentication.Handlers
{
    public class RegisterAdminCommandHandler : IRequestHandler<RegisterAdminCommand, BaseUser>
    {
        
        private readonly UserManager<BaseUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public RegisterAdminCommandHandler(UserManager<BaseUser> userManager, RoleManager<IdentityRole> roleManager,
            IMapper mapper,IAuthenticationService authenticationService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        public async Task<BaseUser> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(request.model.Email);

            if (userExists != null)
                throw new Exception("User already exist");

            BaseUser user = _mapper.Map<BaseUser>(request.model);

            var result = await _userManager.CreateAsync(user,request.model.Password);


            if (await _roleManager.RoleExistsAsync(request.role))
            {
                await _userManager.AddToRoleAsync(user, request.role);
            }

            if (!result.Succeeded)
               throw new Exception("User creation failed! Please check user details and try again.");

            return user;

        }
    }
}
