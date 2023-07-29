using Mappings.DTOs.BusLine;
using MediatR;

namespace BusStation.Mediator.BusLine.Queries
{
    public record GetBusLineListForWorkerQuery(string username):IRequest<BusLineWithCountReadDTO>;
}
