using Mappings.DTOs.Bus;
using MediatR;

namespace BusStation.Mediator.Bus.Commands
{
    public record AddBusCommand(BusCreateDTO bus) :IRequest<BusReadDTO>;
}
