using Mappings.DTOs.Authentication;
using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace BusStation.Mediator.Authentication.Queries
{
    public record LoginQuery(LoginModel model):IRequest<LoginAndRegisterReturnModel>; 

}
