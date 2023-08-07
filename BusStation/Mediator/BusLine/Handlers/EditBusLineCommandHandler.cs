using BusinessLogic.UnitOfWork;
using BusStation.Mediator.BusLine.Commands;
using MediatR;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class EditBusLineCommandHandler : IRequestHandler<EditBusLineCommand,bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditBusLineCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(EditBusLineCommand request, CancellationToken cancellationToken)
        {
            var res = await _unitOfWork.BusLineService.EditBusLine(request.editDTO);

            if (!res)
                return false;

            var IsSuccess = await _unitOfWork.SaveAsync() > 0;
            return IsSuccess;
        }
    }
}
