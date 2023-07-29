using Mappings.DTOs.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BusStation.Mediator.Authentication.Queries
{
    public record RegisterCommand(RegisterModel model):IRequest<LoginAndRegisterReturnModel>;
}
