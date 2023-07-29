﻿using AutoMapper;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.BusLine.Queries;
using Data.Models;
using Mappings.DTOs.BusLine;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class GetBusLineListForWorkerQueryHandler : IRequestHandler<GetBusLineListForWorkerQuery, BusLineWithCountReadDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<BaseUser> _userManager;

        public GetBusLineListForWorkerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<BaseUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<BusLineWithCountReadDTO> Handle(GetBusLineListForWorkerQuery request, CancellationToken cancellationToken)
        {
            var busLines = await _unitOfWork.BusLineService.GetAllBusLinesForWorker(request.username);

            var busLinesDTO = _mapper.Map<List<BusLineReadDTO>>(busLines);
            int count = busLinesDTO.Count;  // Count from ef core   

            foreach (var item in busLinesDTO)
            {
                foreach (var bl in item.BusLineUsers)
                {
                    bl.User.Roles = await _userManager.GetRolesAsync(_mapper.Map<BaseUser>(bl.User));
                }
            }

            BusLineWithCountReadDTO res = new(count, null, busLinesDTO);

            return res;
        }
    }
}