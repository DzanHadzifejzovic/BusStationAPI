using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusStation.Mediator.Authentication.Queries
{
    public record LogoutQuery(string userId):IRequest<string>;
}
