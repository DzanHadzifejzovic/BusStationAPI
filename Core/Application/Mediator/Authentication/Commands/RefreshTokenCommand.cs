using BusStation_API.Core.Domain.Entities;
using MediatR;

namespace Mediator.Authentication.Commands
{
   public record RefreshTokenCommand(TokenModel tokenModel) :IRequest<TokenModel>;
}
