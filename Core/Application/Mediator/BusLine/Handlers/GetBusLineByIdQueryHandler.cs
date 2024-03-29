using AutoMapper;
using BusStation.Mediator.BusLine.Queries;
using BusStation_API.Core.Application.DTOs.BusLine;
using BusStation_API.Core.Domain.Entities;
using BusStation_API.Core.Domain.Interfaces;
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
        
    }
}
