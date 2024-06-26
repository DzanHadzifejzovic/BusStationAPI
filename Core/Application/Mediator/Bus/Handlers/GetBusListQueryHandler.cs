﻿using AutoMapper;
using BusStation.Mediator.Bus.Queries;
using BusStation_API.Core.Application.DTOs.Bus;
using BusStation_API.Core.Domain.Interfaces;
using MediatR;

namespace BusStation.Mediator.Bus.Handlers
{
    public class GetBusListQueryHandler : IRequestHandler<GetBusListQuery, List<BusReadDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBusListQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<BusReadDTO>> Handle(GetBusListQuery request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<List<BusReadDTO>>(await _unitOfWork.BusService.GetAllAsync());
            return data;
        }
    }
}
