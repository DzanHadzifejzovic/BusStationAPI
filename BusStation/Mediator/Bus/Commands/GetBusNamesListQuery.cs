using MediatR;

namespace BusStation.Mediator.Bus.Commands
{
    public record GetBusNamesListQuery:IRequest<List<string>>;

}
