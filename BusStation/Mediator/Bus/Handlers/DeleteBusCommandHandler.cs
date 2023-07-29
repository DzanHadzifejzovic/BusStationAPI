using AutoMapper;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.Bus.Commands;
using MediatR;

namespace BusStation.Mediator.Bus.Handlers
{
    public class DeleteBusCommandHandler : IRequestHandler<DeleteBusCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteBusCommand request, CancellationToken cancellationToken)
        {
            var bus = await _unitOfWork.BusService.DeleteBus(request.busId);

            if (!bus)
                return false;

            try
            {
                var IsSuccess = await _unitOfWork.SaveAsync() > 0;
                return IsSuccess;
            }
            catch(Exception ex)
            {
                return false;
            } 
        }

    }
}
