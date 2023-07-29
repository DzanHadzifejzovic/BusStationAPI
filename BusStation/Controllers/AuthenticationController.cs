using BusinessLogic.Interfaces;
using BusStation.Mediator.Authentication.Commands;
using BusStation.Mediator.Authentication.Queries;
using BusStation.Mediator.User.Queries;
using Data.Models;
using Mappings.DTOs.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BusStation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IMediator mediator,
                        IAuthenticationService refreshTokenRepository)
        {
            _mediator = mediator;
            _authenticationService = refreshTokenRepository;
        }


        [HttpGet("get-role-for-user-from-token")]
        public async Task<string> GetRole([FromHeader]string myToken)
        {
            var result = await _mediator.Send(new GetRoleForUserQuery(myToken));
            return result;
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<LoginAndRegisterReturnModel> Login([FromBody] LoginModel model)
        {
            var result = await _mediator.Send(new LoginQuery(model));
            return result;
        }

        [HttpPost("register-admin")]
        public async Task<BaseUser> RegisterAdmin([FromBody] RegisterModel model,string? role="Buyer") 
        {
            var result = await _mediator.Send(new RegisterAdminCommand(model,role));
            return result;
        }

        [HttpPost("register")]
        public async Task<LoginAndRegisterReturnModel> Register([FromBody] RegisterModel model)
        {
            var result = await _mediator.Send(new RegisterCommand(model));
            return result;
        }


        [HttpPost]
        [Route("refresh-access-token")]
        public async Task<TokenModel> RefreshToken([FromBody]TokenModel tokenModel)
        {
            var result = await _mediator.Send(new RefreshTokenCommand(tokenModel));
            return result;
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            /*var rawUserId = HttpContext.User.FindFirstValue("id");
           
            var result = await _mediator.Send(new LogoutQuery(rawUserId));

            return Ok(result);*/
            return Ok("Logout success");
        }

    }
}
