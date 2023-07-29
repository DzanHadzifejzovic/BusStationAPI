using Mappings.DTOs.BaseUser;
using MediatR;

namespace BusStation.Mediator.User.Queries
{
    public record GetConductorsQuery() : IRequest<List<BaseUserReadDTO>>;
}
