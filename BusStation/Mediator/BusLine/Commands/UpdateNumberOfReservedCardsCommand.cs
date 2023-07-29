using MediatR;

namespace BusStation.Mediator.BusLine.Commands
{
    public record UpdateNumberOfReservedCardsCommand(int busLineId,int numOfCards) : IRequest<bool>;
}
