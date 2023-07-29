using AutoMapper;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.BusLine.Commands;
using MediatR;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class UpdateNumberOfReservedCardsCommandHandler : IRequestHandler<UpdateNumberOfReservedCardsCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNumberOfReservedCardsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateNumberOfReservedCardsCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BusLineService.ChangeNumberOfReservedCards(request.busLineId, request.numOfCards);
            if (!result)
                return false;

            var IsSuccess = await _unitOfWork.SaveAsync() > 0;
            return IsSuccess;
        }
    }
}
