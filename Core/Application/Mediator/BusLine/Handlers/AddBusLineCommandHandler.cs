using AutoMapper;
using BusStation.Mediator.BusLine.Commands;
using BusStation_API.Core.Domain.Entities;
using BusStation_API.Core.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class AddBusLineCommandHandler : IRequestHandler<AddBusLineCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<BaseUser> _userManager;

        public AddBusLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<BaseUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<int> Handle(AddBusLineCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<BusStation_API.Core.Domain.Entities.BusLine>(request.busLine);

            var conductor = await _userManager.FindByIdAsync(request.busLine.ConductorId);
            result.BusLineUsers.Add(new BusLineUser{ User = conductor });
    
            var driver = await _userManager.FindByIdAsync(request.busLine.DriverId);
            result.BusLineUsers.Add(new BusLineUser{ User = driver });

            await _unitOfWork.BusLineService.AddBusLine(result);

            var IsSuccess = await _unitOfWork.SaveAsync() > 0;
            if (!IsSuccess)
                throw new Exception("Something went wrong while saving data into database");

            return result.Id;
        }
    }
}
