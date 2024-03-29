using MediatR;

namespace BusStation.Mediator.User.Commands
{
    public record DeleteUserCommand(string userId):IRequest<bool>;
}
