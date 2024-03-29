using MediatR;

namespace BusStation.Mediator.User.Queries
{
    public record GetRoleForUserQuery(string token):IRequest<string>;
}
