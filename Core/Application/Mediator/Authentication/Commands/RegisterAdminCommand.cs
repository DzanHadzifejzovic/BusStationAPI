using MediatR;
using BusStation_API.Core.Application.DTOs.Authentication;
using BusStation_API.Core.Domain.Entities;

namespace Mediator.Authentication.Queries
{
    public record RegisterAdminCommand(RegisterModel model,string? role="Buyer"):IRequest<BaseUser>;
}
