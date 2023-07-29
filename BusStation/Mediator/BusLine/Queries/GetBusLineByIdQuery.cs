using Mappings.DTOs.BusLine;
using MediatR;

namespace BusStation.Mediator.BusLine.Queries
{
    public record GetBusLineByIdQuery(int busLineId):IRequest<BusLineReadDTO>;
}
