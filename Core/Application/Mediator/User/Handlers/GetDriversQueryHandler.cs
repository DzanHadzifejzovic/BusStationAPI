using AutoMapper;
using BusStation.Mediator.User.Queries;
using BusStation_API.Core.Application.DTOs.BaseUser;
using BusStation_API.Core.Domain.Entities;
using BusStation_API.Core.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusStation.Mediator.User.Handlers
{
    public class GetDriversQueryHandler : IRequestHandler<GetDriversQuery, List<BaseUserReadDTO>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<BaseUser> _userManager;

        public GetDriversQueryHandler(IUserService authenticationService, IMapper mapper,
            UserManager<BaseUser> userManager)
        {
            _userService = authenticationService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<List<BaseUserReadDTO>> Handle(GetDriversQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetWorkers();
            var resultDTO = _mapper.Map<List<BaseUserReadDTO>>(users);
            foreach (var item in resultDTO)
            {
                item.Roles = await _userManager.GetRolesAsync(users.Find(l => l.Id == item.Id));
            }
            resultDTO = resultDTO.Where(r => r.Roles.Contains("Driver"))
                        .ToList();
            return resultDTO;
        }
    }
}
