using AutoMapper;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.BusLine.Queries;
using Data.Models;
using Mappings.DTOs.BaseUser;
using Mappings.DTOs.Bus;
using Mappings.DTOs.BusLine;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class GetBusLineByIdQueryHandler : IRequestHandler<GetBusLineByIdQuery, BusLineReadDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<BaseUser> _userManager;

        public GetBusLineByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<BaseUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<BusLineReadDTO> Handle(GetBusLineByIdQuery request, CancellationToken cancellationToken)
        {
            var busLine = await _unitOfWork.BusLineService.GetBusLineById(request.busLineId);

            var busLineDTO = _mapper.Map<BusLineReadDTO>(busLine);

            foreach (var item in busLineDTO.BusLineUsers)
            {
                item.User.Roles = await _userManager.GetRolesAsync(_mapper.Map<BaseUser>(item.User)); 
            }
            return busLineDTO;
        }
        /*
            var busLineDTO = new BusLineReadDTO
            {
                Id = busLine.Id,
                RoadRoute = busLine.RoadRoute,
                DepartureTime = busLine.DepartureTime,
                CardPrice = busLine.CardPrice,
                NumberOfPlatform=busLine.NumberOfPlatform,
                Delay = busLine.Delay,
                NumberOfReservedCards=busLine.NumberOfReservedCards,
                BusId = busLine.BusId,
                Bus = _mapper.Map<BusReadDTO>(busLine.Bus),
                Users = busLine.BusLineUsers.Select(async blu =>
                {
                    var user = blu.User;
                    var userRoles = await _userManager.GetRolesAsync(user);

                    return new BaseUserReadDTO
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Country = user.Country,
                        City = user.City,
                        Address = user.Address,
                        Roles = userRoles.ToList()
                    };
                }).Select(t => t.Result).ToList()
            };
            */
    }
}
