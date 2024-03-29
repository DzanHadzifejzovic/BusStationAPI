using MediatR;

namespace Mediator.Authentication.Queries
{
    public record LogoutQuery(string userId):IRequest<string>;
}
