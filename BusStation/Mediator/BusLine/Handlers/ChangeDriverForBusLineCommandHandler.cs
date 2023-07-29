using BusinessLogic.UnitOfWork;
using BusStation.Mediator.BusLine.Commands;
using MediatR;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class ChangeDriverForBusLineCommandHandler : IRequestHandler<ChangeDriverForBusLineCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeDriverForBusLineCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(ChangeDriverForBusLineCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BusLineService.ChangeDriverForBusLine(request.busLineId, request.oldDriverId, request.driverId);
            if (!result)
                return false;

            var IsSuccess = await _unitOfWork.SaveAsync() > 0;
            return IsSuccess;
        }
    }
}
