using Data.Models;
using MediatR;

namespace BusStation.Mediator.Authentication.Commands
{
   public record RefreshTokenCommand(TokenModel tokenModel) :IRequest<TokenModel>;
}
