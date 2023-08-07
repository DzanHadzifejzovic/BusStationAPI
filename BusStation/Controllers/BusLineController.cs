using Data.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Mappings.DTOs.BusLine;
using BusStation.Mediator.BusLine.Queries;
using BusStation.Mediator.BusLine.Commands;
using Microsoft.AspNetCore.Authorization;
using Sieve.Models;
using Sieve.Services;
using BusStation.Mediator.User.Queries;
using BusStation.Mediator.Bus.Queries;

namespace BusStation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusLineController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISieveProcessor _sieveProcessor;
        public BusLineController(IMediator mediator, ISieveProcessor sieveProcessor)
        {
            _mediator = mediator;
            _sieveProcessor = sieveProcessor;
        }

        //upitno
        //[Authorize(Roles = "Admin,CounterWorker,Driver,Conducotr,Buyer")] //for Buyer dont show info for workers
        [HttpGet("bus-lines")]
        public async Task<IActionResult> Get([FromQuery] SieveModel sieveModel) 
        { 
            var result = await _mediator.Send(new GetBusLineListQuery());
            var sieved =  _sieveProcessor.Apply(sieveModel, result.BusLines.AsQueryable());
            BusLineWithCountReadDTO final = new(result.CountAllBusLines, sieved.Count(), sieved.ToList());
            return Ok(final);
        }

        //[Authorize(Roles = "Driver,Conducotr")] //for Buyer dont show info for workers
        [HttpGet("bus-lines/worker")]
        public async Task<IActionResult> GetBusLinesForWorker([FromQuery] SieveModel sieveModel,[FromQuery] string username) //Task<ActionResult<List<BusLineReadDTO>>>
        {
            var result = await _mediator.Send(new GetBusLineListForWorkerQuery(username));
            var sieved = _sieveProcessor.Apply(sieveModel, result.BusLines.AsQueryable());
            BusLineWithCountReadDTO final = new(result.CountAllBusLines, sieved.Count(), sieved.ToList());
            return Ok(final);
        }

        //[Authorize(Roles = "Admin,CounterWorker,Buyer")] //for Buyer dont show info for workers
        [HttpGet("{busLineId}")]
        public async Task<ActionResult<BusLineReadDTO>> GetById(int busLineId)
        {
            var result = await _mediator.Send(new GetBusLineByIdQuery(busLineId));
            return Ok(result);
        }
      
        [HttpGet("numbers-of-platforms")]
        public async Task<ActionResult<BusLineReadDTO>> GetAllNumberForPlatform()
        {
            var result = await _mediator.Send(new GetAllNumbersOfPlatformsQuery());
            return Ok(result);
        }
        [Authorize(Roles = "Admin,CounterWorker")]
        [HttpGet("get-data-for-busLine-edit-page")]
        public async Task<ActionResult<BusLineEditDataDTO>> GetDataForEditPage([FromQuery]int? busLineId)
        {
            BusLineReadDTO busLine =new();

            if (busLineId!=null)
            {
                 busLine = await _mediator.Send(new GetBusLineByIdQuery((int)busLineId));
            }

            var buses = await _mediator.Send(new GetBusListQuery());
            var goodBuses = buses.Where(b=>b.DrivingCondition=true).ToList();
            var drivers = await _mediator.Send(new GetDriversQuery());
            var conductors = await _mediator.Send(new GetConductorsQuery());

            var result = new BusLineEditDataDTO(busLine,goodBuses, drivers, conductors);
            return Ok(result);
        }


        //[Authorize(Roles = "Admin,CounterWorker")]
        [HttpPost]
        public async Task<ActionResult<BusLine>> Post([FromBody] BusLineCreateDTO busLine)
        {
            int result = await _mediator.Send(new AddBusLineCommand(busLine));
            var res = await GetById(result);
            return Created("https://localhost:7075/api/BusLine/" + result, res.Result);
        }

        [Authorize(Roles = "Admin,CounterWorker")]
        [HttpDelete("{busLineId}")]
        public async Task<ActionResult> Delete(int busLineId)
        {
            var result = await _mediator.Send(new DeleteBusLineCommand(busLineId));
            return Ok(result);//return true if it's deleted
        }

        [Authorize(Roles = "Admin,CounterWorker")]
        [HttpPatch("edit-busLine")]
        public async Task<ActionResult<string>> UpdateDepartureTime([FromBody]BusLineInputForEditDTO editDTO)
        {
            var result = await _mediator.Send(new EditBusLineCommand(editDTO));
            return Ok(result);
        }

    }
}
