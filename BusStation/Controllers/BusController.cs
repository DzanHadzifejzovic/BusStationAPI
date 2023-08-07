using Microsoft.AspNetCore.Mvc;
using MediatR;
using BusStation.Mediator.Bus.Queries;
using Mappings.DTOs.Bus;
using BusStation.Mediator.Bus.Commands;
using Microsoft.AspNetCore.Authorization;

namespace BusStation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusController(IMediator mediator)
        { 
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin,CounterWorker,Conductor,Driver")]
        [HttpGet]
        public async Task<List<BusReadDTO>> Get()
        {
            var result = await _mediator.Send(new GetBusListQuery());
            return result;
        }
        [HttpGet("bus-names")]
        public async Task<List<string>> GetAllBusNames()
        {
            var result = await _mediator.Send(new GetBusNamesListQuery());
            return result;
        }
        [Authorize(Roles = "Admin,CounterWorker,Conductor,Driver")]
        [HttpGet("{busId}")]
        public async Task<BusReadDTO> GetById(int busId)
        {
            var result = await _mediator.Send(new GetBusByIdQuery(busId));
            return result;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<BusReadDTO>> Post([FromBody] BusCreateDTO bus)
        {
            var result = await _mediator.Send(new AddBusCommand(bus));
            return CreatedAtAction(nameof(GetById), new { busId = result.Id }, result);
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{busId}")]
        public async Task<ActionResult> Delete(int busId)
        {
            var result = await _mediator.Send(new DeleteBusCommand(busId));
            return Ok(result);
        }
        //[Authorize(Roles = "Driver")]
        [HttpPatch("report-fault/{busId}")]
        public async Task<ActionResult> SetDrivingCondition(int busId)
        {
            var result = await _mediator.Send(new SetDrivingConditionCommand(busId));
            return Ok(result);//return true if it's changed
        }



    }
}
