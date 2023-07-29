using Data.Models;
using Mappings.DTOs.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BusStation.Mediator.Authentication.Queries
{
    public record RegisterAdminCommand(RegisterModel model,string? role="Buyer"):IRequest<BaseUser>;
}
