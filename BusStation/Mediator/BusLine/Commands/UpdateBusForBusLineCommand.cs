using MediatR;

namespace BusStation.Mediator.BusLine.Commands
{
    public record UpdateBusForBusLineCommand(int busLineId,int busId):IRequest<bool>;
}
