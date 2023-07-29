using BusinessLogic.Interfaces;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.BusLine.Commands;
using MediatR;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class UpdateBusForBusLineCommandHandler : IRequestHandler<UpdateBusForBusLineCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusLineService _busLineService;

        public UpdateBusForBusLineCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateBusForBusLineCommand request, CancellationToken cancellationToken)
        {
            var res = await _unitOfWork.BusLineService.ChangeBusForBusLine(request.busLineId, request.busId);

            if (!res)
                return false;

            var IsSuccess = await _unitOfWork.SaveAsync() > 0;
            return IsSuccess;
        }
    }
}
