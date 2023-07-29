using AutoMapper;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.Bus.Queries;
using Mappings.DTOs.Bus;
using MediatR;

namespace BusStation.Mediator.Bus.Handlers
{
    public class GetBusByIdQueryHandler : IRequestHandler<GetBusByIdQuery, BusReadDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBusByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BusReadDTO> Handle(GetBusByIdQuery request, CancellationToken cancellationToken)
        {
            var res =  _mapper.Map<BusReadDTO>(await _unitOfWork.BusService.GetById(request.busId));
            return res;
        }
    }
}
