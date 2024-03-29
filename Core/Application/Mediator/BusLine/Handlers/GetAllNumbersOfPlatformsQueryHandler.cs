using BusStation.Mediator.BusLine.Commands;
using BusStation_API.Core.Domain.Interfaces;
using MediatR;

namespace BusStation.Mediator.BusLine.Handlers
{
    public class GetAllNumbersOfPlatformsQueryHandler : IRequestHandler<GetAllNumbersOfPlatformsQuery, List<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllNumbersOfPlatformsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<int>> Handle(GetAllNumbersOfPlatformsQuery request, CancellationToken cancellationToken)
        {
            var resp = await _unitOfWork.BusLineService.GetAllNumbersOfPlatforms();
            return resp;
        }
    }
}
