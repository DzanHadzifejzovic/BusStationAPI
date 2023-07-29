using AutoMapper;
using BusinessLogic.Interfaces;
using BusStation.Mediator.User.Queries;
using Data.Models;
using Mappings.DTOs.BaseUser;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusStation.Mediator.User.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, BaseUserReadDTO?>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<BaseUser> _userManager;

        public GetEmployeeByIdQueryHandler(IUserService authenticationService, IMapper mapper,
            UserManager<BaseUser> userManager)
        {
            _userService = authenticationService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<BaseUserReadDTO?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var emp = await _userService.GetWorkerById(request.employeeId);
            if (emp == null)
                return null;
            
            var result = _mapper.Map<BaseUserReadDTO>(emp);
            result.Roles = await _userManager.GetRolesAsync(emp);
            return result;
        }
    }
}
