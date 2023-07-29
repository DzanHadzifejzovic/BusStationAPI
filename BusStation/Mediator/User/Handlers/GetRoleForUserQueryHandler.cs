using BusinessLogic.Interfaces;
using BusStation.Mediator.User.Queries;
using MediatR;

namespace BusStation.Mediator.User.Handlers
{
    public class GetRoleForUserQueryHandler : IRequestHandler<GetRoleForUserQuery, string>
    {
        private readonly IUserService _userService;

        public GetRoleForUserQueryHandler(IUserService authenticationService)
        {
           _userService = authenticationService;
        }
        public async Task<string> Handle(GetRoleForUserQuery request, CancellationToken cancellationToken)
        {
            string res = await _userService.GetRolesFromUser(request.token);
            return res;
        }
    }
}
