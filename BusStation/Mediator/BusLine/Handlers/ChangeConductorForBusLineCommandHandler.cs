using BusinessLogic.UnitOfWork;
using BusStation.Mediator.BusLine.Commands;
using MediatR;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class ChangeConductorForBusLineCommandHandler : IRequestHandler<ChangeConductorForBusLineCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeConductorForBusLineCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(ChangeConductorForBusLineCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BusLineService.ChangeConductorForBusLine(request.busLineId,request.oldConductorId,request.conductorId);            
            if (!result)
                return false;

            var IsSuccess = await _unitOfWork.SaveAsync() > 0;
            return IsSuccess;
        }
    }
}
