using MediatR;

namespace BusStation.Mediator.Bus.Commands
{
    public record DeleteBusCommand(int busId) :IRequest<bool>;
}
