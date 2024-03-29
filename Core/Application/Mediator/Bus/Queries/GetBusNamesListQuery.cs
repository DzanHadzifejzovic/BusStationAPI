using MediatR;

namespace BusStation.Mediator.Bus.Queries
{
    public record GetBusNamesListQuery:IRequest<List<string>>;

}
