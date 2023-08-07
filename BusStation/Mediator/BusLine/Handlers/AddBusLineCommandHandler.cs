using AutoMapper;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.BusLine.Commands;
using MediatR;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class AddBusLineCommandHandler : IRequestHandler<AddBusLineCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddBusLineCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
