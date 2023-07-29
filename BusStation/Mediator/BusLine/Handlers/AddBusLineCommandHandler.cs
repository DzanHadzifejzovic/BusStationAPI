using AutoMapper;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.BusLine.Commands;
using Data.Models;
using Mappings.DTOs.Bus;
using Mappings.DTOs.BusLine;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class AddBusLineCommandHandler : IRequestHandler<AddBusLineCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddBusLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddBusLineCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BusLineService.AddBusLine(request.busLine);
            var IsSuccess = await _unitOfWork.SaveAsync() > 0;
            if (!IsSuccess)
                throw new Exception("Something went wrong while saving data into database");

            return result.Id;

        }
    }
}
