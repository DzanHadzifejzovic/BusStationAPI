using MediatR;

namespace BusStation.Mediator.BusLine.Commands
{
    public record DeleteBusLineCommand(int busLineId):IRequest<bool>;
}
