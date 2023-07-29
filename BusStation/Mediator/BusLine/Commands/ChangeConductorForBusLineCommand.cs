using MediatR;

namespace BusStation.Mediator.BusLine.Commands
{
    public record ChangeConductorForBusLineCommand(int busLineId, string oldConductorId, string conductorId) :IRequest<bool>;
}
