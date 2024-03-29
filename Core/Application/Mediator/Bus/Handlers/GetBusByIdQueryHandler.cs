using AutoMapper;
using BusStation.Mediator.Bus.Queries;
using BusStation_API.Core.Application.DTOs.Bus;
using BusStation_API.Core.Domain.Interfaces;
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
