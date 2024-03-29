using AutoMapper;
using BusStation.Mediator.User.Queries;
using BusStation_API.Core.Application.DTOs.BaseUser;
using BusStation_API.Core.Domain.Entities;
using BusStation_API.Core.Domain.Interfaces;
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
            //result.Roles = await _userManager.GetRolesAsync(emp);
            return result;
        }
    }
}
