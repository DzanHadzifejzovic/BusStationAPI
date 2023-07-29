using MediatR;

namespace BusStation.Mediator.Bus.Commands
{
    public record SetDrivingConditionCommand(int busId):IRequest<bool>;
}
