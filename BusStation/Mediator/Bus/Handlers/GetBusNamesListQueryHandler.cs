using BusinessLogic.UnitOfWork;
using BusStation.Mediator.Bus.Commands;
using MediatR;

namespace BusStation.Mediator.Bus.Handlers
{
    public class GetBusNamesListQueryHandler : IRequestHandler<GetBusNamesListQuery, List<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBusNamesListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public  async Task<List<string>> Handle(GetBusNamesListQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.BusService.GetNameOfBuses();
            return data;
        }
    }
}
