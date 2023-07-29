using Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusStation.Mediator.Authentication.Commands
{
    public record RefreshTokenCommand(TokenModel tokenModel) :IRequest<TokenModel>;
}
