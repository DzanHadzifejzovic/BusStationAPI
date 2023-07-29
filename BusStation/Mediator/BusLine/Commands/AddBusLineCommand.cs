using Mappings.DTOs.BusLine;
using MediatR;

namespace BusStation.Mediator.BusLine.Commands
{
    public record AddBusLineCommand(BusLineCreateDTO busLine):IRequest<int>;
}
