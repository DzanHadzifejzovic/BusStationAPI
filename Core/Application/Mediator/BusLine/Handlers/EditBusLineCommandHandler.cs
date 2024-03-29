using AutoMapper;
using BusStation.Mediator.BusLine.Commands;
using BusStation_API.Core.Domain.Entities;
using BusStation_API.Core.Domain.Interfaces;
using MediatR;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class EditBusLineCommandHandler : IRequestHandler<EditBusLineCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditBusLineCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(EditBusLineCommand request, CancellationToken cancellationToken)
        {

            var existingBusLine = await _unitOfWork.BusLineService.GetBusLineById(request.editDTO.Id);

            if (existingBusLine == null)
            {
                return false;
            }

            if (request.editDTO.ConductorId != "" && request.editDTO.ConductorId != request.editDTO.OldConductorId)
            {
                var conductorUser = existingBusLine.BusLineUsers.FirstOrDefault(u => u.UserId == request.editDTO.OldConductorId);
                var clonedConductorUser = new BusLineUser(conductorUser)
                {
                    UserId = request.editDTO.ConductorId,
                };
                existingBusLine.BusLineUsers.Add(clonedConductorUser);
                existingBusLine.BusLineUsers.Remove(conductorUser);
            }
            if (request.editDTO.DriverId!="" && request.editDTO.DriverId != request.editDTO.OldDriverId)
            {
                var driverUser = existingBusLine.BusLineUsers.FirstOrDefault(u => u.UserId == request.editDTO.OldDriverId);
                var clonedDriverUser = new BusLineUser(driverUser)
                {
                    UserId = request.editDTO.DriverId,
                };
                existingBusLine.BusLineUsers.Add(clonedDriverUser);
                existingBusLine.BusLineUsers.Remove(driverUser);
            }

            existingBusLine.DepartureTime = request.editDTO.DepartureTime != existingBusLine.DepartureTime ? request.editDTO.DepartureTime : existingBusLine.DepartureTime;
            existingBusLine.BusId = request.editDTO.BusId != existingBusLine.BusId ? request.editDTO.BusId : existingBusLine.BusId;
            bool isSeatsAvailable = CheckAvailableSeats(existingBusLine.Bus.NumberOfSeats,existingBusLine.NumberOfReservedCards,request.editDTO.NumberOfReservedCards);
            if (isSeatsAvailable)
            {
                existingBusLine.NumberOfReservedCards =
                request.editDTO.NumberOfReservedCards != existingBusLine.NumberOfReservedCards ? request.editDTO.NumberOfReservedCards + existingBusLine.NumberOfReservedCards : existingBusLine.NumberOfReservedCards;
            }
            else 
                throw new Exception("The number of reserved cards cannot exceed the number of seats.");  
            
            var res = await _unitOfWork.BusLineService.EditBusLine(existingBusLine);

            var IsSuccess = await _unitOfWork.SaveAsync() > 0;
            return IsSuccess;
        }

        private bool CheckAvailableSeats(int numOfAvailableSeats,int alreadyReservedCards,int addNumOfCards)
        {
            if (addNumOfCards > numOfAvailableSeats)
                return false;
            
            if ((alreadyReservedCards+addNumOfCards) > numOfAvailableSeats)
                return false;


            return true;
        }

    }
}
