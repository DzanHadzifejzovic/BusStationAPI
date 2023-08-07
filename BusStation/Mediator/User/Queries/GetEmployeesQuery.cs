using Mappings.DTOs.BaseUser;
using MediatR;

namespace BusStation.Mediator.User.Queries
{
    public record GetEmployeesQuery : IRequest<BaseUserWithCountReadDTO>;
}
