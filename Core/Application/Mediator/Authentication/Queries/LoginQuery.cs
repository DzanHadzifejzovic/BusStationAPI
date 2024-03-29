using BusStation_API.Core.Application.DTOs.Authentication;
using MediatR;

namespace Mediator.Authentication.Queries
{
    public record LoginQuery(LoginModel model):IRequest<LoginAndRegisterReturnModel>; 

}
