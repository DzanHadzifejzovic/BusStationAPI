using AutoMapper;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.BusLine.Commands;
using MediatR;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class ChangeDepartureTimeCommandHandler : IRequestHandler<ChangeDepartureTimeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeDepartureTimeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(ChangeDepartureTimeCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BusLineService.ChangeDepartureTime(request.busLineId,request.dateTime);
            if (!result)
                return false;

            var IsSuccess = await _unitOfWork.SaveAsync() > 0;
            return IsSuccess;
        }
    }
}
