using AutoMapper;
using BusinessLogic.Interfaces;
using BusStation.Mediator.User.Queries;
using Data.Models;
using Mappings.DTOs.BaseUser;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusStation.Mediator.User.Handlers
{
    public class GetConductorsQueryHandler : IRequestHandler<GetConductorsQuery, List<BaseUserReadDTO>>
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<BaseUser> _userManager;

        public GetConductorsQueryHandler(IUserService authenticationService, IMapper mapper,
            UserManager<BaseUser> userManager)
        {
            _userService = authenticationService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<List<BaseUserReadDTO>> Handle(GetConductorsQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetWorkers();
            var resultDTO = _mapper.Map<List<BaseUserReadDTO>>(users);
            foreach (var item in resultDTO)
            {
                item.Roles = await _userManager.GetRolesAsync(users.Find(l => l.Id == item.Id));
            }
            resultDTO = resultDTO.Where(r => r.Roles.Contains("Conductor"))
                        .ToList();

            return resultDTO;
        }
    }
}
