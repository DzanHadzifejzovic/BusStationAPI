using Mappings.DTOs.Bus;
using MediatR;

namespace BusStation.Mediator.Bus.Queries
{
   public record GetBusListQuery():IRequest<List<BusReadDTO>>;  
}
