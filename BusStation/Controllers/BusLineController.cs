using Data.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Mappings.DTOs.BusLine;
using BusStation.Mediator.BusLine.Queries;
using BusStation.Mediator.BusLine.Commands;
using Microsoft.AspNetCore.Authorization;
using Sieve.Models;
using Sieve.Services;
using System.Configuration;

//Add method getbyplatform or/and getbyLocation like SEARCH BY LOCATION(conatains character)//SOLVE IT WITH FILTGERING @=
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

        //[Authorize(Roles = "Admin,CounterWorker,Driver,Conducotr,Buyer")] //for Buyer dont show info for workers
        [HttpGet("bus-lines")]
        public async Task<IActionResult> Get([FromQuery] SieveModel sieveModel) //Task<ActionResult<List<BusLineReadDTO>>>
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

        //[Authorize(Roles ="Admin,Driver")]
        [HttpPatch("change-departure-time")]
        public async Task<ActionResult<string>> UpdateDepartureTime(int busLineId,DateTime dateTime)
        {
            var result = await _mediator.Send(new ChangeDepartureTimeCommand(busLineId,dateTime));
            return Ok(result);
        }

        //[Authorize(Roles = "CounterWorker,Conductor")]
        [HttpPatch("update-reserved-cards")]
        public async Task<ActionResult<string>> UpdateNumberOfCards(int busLineId,int numOfCards)
        {
            var result = await _mediator.Send(new UpdateNumberOfReservedCardsCommand(busLineId, numOfCards));
            return Ok(result);
        }
        //[Authorize(Roles = "CounterWorker,Conductor")]
        [HttpPatch("update-bus-for-busLine")]
        public async Task<ActionResult<string>> UpdateBusForBusLine(int busLineId, int busId)
        {
            var result = await _mediator.Send(new UpdateBusForBusLineCommand(busLineId, busId));
            return Ok(result);
        }

        [HttpPatch("update-conductor-for-busLine")]
        public async Task<ActionResult<string>> UpdateConductorForBusLine(int busLineId, string oldConductorId, string conductorId)
        {
            var result = await _mediator.Send(new ChangeConductorForBusLineCommand(busLineId, oldConductorId,conductorId));
            return Ok(result);
        }
        [HttpPatch("update-driver-for-busLine")]
        public async Task<ActionResult<string>> UpdateDriverForBusLine(int busLineId, string oldDriverId, string driverId)
        {
            var result = await _mediator.Send(new ChangeDriverForBusLineCommand(busLineId, oldDriverId, driverId));
            return Ok(result);
        }     
    }
}
