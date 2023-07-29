using AutoMapper;
using BusinessLogic.Interfaces;
using BusStation.Mediator.User.Queries;
using Data.Models;
using Mappings.DTOs.BaseUser;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusStation.Mediator.User.Handlers
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery,BaseUserWithCountReadDTO>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<BaseUser> _userManager;

        public GetEmployeesQueryHandler(IUserService authenticationService,IMapper mapper,
            UserManager<BaseUser> userManager)
        {
            _userService = authenticationService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<BaseUserWithCountReadDTO> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetWorkers();
            var resultDTO = _mapper.Map<List<BaseUserReadDTO>>(users);
            foreach(var item in resultDTO)
            {
                item.Roles = await _userManager.GetRolesAsync(users.Find(l => l.Id == item.Id));
            }
            int count = resultDTO.Count;  // Count from ef core   
            resultDTO = resultDTO.OrderBy(e => e.Roles.FirstOrDefault())
                        .ToList();
            BaseUserWithCountReadDTO res = new(count, null, resultDTO);

            return res;
        }
    }
}
