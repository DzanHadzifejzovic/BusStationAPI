using AutoMapper;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.BusLine.Commands;
using MediatR;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class DeleteBusLineCommandHandler : IRequestHandler<DeleteBusLineCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBusLineCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteBusLineCommand request, CancellationToken cancellationToken)
        {
            var busLine = await _unitOfWork.BusLineService.DeleteBusLine(request.busLineId);

            if (!busLine)
                return false;
            
            var IsSuccess = await _unitOfWork.SaveAsync() > 0;
            return IsSuccess;
        }
    }
}
