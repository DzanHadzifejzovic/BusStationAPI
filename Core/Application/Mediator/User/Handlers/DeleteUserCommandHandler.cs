using BusStation.Mediator.User.Commands;
using BusStation_API.Core.Domain.Interfaces;
using MediatR;

namespace BusStation.Mediator.User.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUserService userService,IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _userService.DeleteUserById(request.userId);
            if (!isDeleted)
                return false;

            var IsSuccess = await _unitOfWork.SaveAsync() > 0;
            return IsSuccess;
        }
    }
}
