using AutoMapper;
using BusinessLogic.UnitOfWork;
using BusStation.Mediator.Bus.Commands;
using Mappings.DTOs.Bus;
using MediatR;

namespace BusStation.Mediator.Bus.Handlers
{
    public class AddBusCommandHandler : IRequestHandler<AddBusCommand, BusReadDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddBusCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BusReadDTO> Handle(AddBusCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BusService.AddBus(request.bus);

            var IsSuccess = await _unitOfWork.SaveAsync() > 0;

            if (!IsSuccess)
                throw new Exception("Something went wrong while saving data into database");

            return _mapper.Map<BusReadDTO>(result);

        }
    }
}
