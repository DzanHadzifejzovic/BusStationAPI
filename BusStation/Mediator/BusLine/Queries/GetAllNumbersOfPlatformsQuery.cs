using MediatR;

namespace BusStation.Mediator.BusLine.Commands
{
    public record GetAllNumbersOfPlatformsQuery:IRequest<List<int>>;
}
