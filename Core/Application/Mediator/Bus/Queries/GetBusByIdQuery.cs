using BusStation_API.Core.Application.DTOs.Bus;
using MediatR;

namespace BusStation.Mediator.Bus.Queries
{
    public record GetBusByIdQuery(int busId):IRequest<BusReadDTO>;
}
