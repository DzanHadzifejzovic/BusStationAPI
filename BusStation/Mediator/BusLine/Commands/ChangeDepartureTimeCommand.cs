using MediatR;

namespace BusStation.Mediator.BusLine.Commands
{
    public record ChangeDepartureTimeCommand(int busLineId,DateTime dateTime):IRequest<bool>;
}
