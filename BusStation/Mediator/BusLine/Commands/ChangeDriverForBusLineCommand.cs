using MediatR;

namespace BusStation.Mediator.BusLine.Commands
{
    public record ChangeDriverForBusLineCommand(int busLineId, string oldDriverId, string driverId) : IRequest<bool>;
}
