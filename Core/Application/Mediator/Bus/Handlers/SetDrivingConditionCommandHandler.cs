using BusStation.Mediator.Bus.Commands;
using BusStation_API.Core.Domain.Interfaces;
using MediatR;

namespace BusStation.Mediator.Bus.Handlers
{
    public class SetDrivingConditionCommandHandler : IRequestHandler<SetDrivingConditionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SetDrivingConditionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(SetDrivingConditionCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BusService.ChangeDrivingConditionToBus(request.busId);

            var IsSuccess = await _unitOfWork.SaveAsync() > 0;

            if (!IsSuccess)
            {
                throw new Exception("Problem with editing data from database");
                return false;
            }
            return true;
        }
    }
}
