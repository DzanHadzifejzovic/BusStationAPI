using Data.Models;
using Mappings.DTOs.Authentication;
using MediatR;

namespace BusStation.Mediator.Authentication.Queries
{
    public record RegisterAdminCommand(RegisterModel model,string? role="Buyer"):IRequest<BaseUser>;
}
