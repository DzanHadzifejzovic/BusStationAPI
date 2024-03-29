using BusStation_API.Core.Application.DTOs.Authentication;
using MediatR;

namespace Mediator.Authentication.Queries
{
    public record RegisterCommand(RegisterModel model):IRequest<LoginAndRegisterReturnModel>;
}
