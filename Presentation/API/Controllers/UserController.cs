using BusStation.Mediator.User.Commands;
using BusStation.Mediator.User.Queries;
using BusStation_API.Core.Application.DTOs.BaseUser;
using BusStation_API.Core.Application.DTOs.SerilogSeq;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sieve.Models;
using Sieve.Services;

namespace BusStation_API.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly ISieveProcessor _sieveProcessor;

        public UserController(IMediator mediator,IConfiguration configuration, ISieveProcessor sieveProcessor)
        {
            _mediator = mediator;
            _configuration = configuration;
            _sieveProcessor = sieveProcessor;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetEmployees([FromQuery] SieveModel sieveModel)
        {
            var result = await _mediator.Send(new GetEmployeesQuery());
            var sieved = _sieveProcessor.Apply(sieveModel, result.Users.AsQueryable());
            BaseUserWithCountReadDTO final = new(result.CountAllUsers, sieved.Count(), sieved.ToList());

            return Ok(final);
        }

        [HttpGet("{employeeId}")]
        public async Task<BaseUserReadDTO> GetEmployeeById(string employeeId)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery(employeeId));
            return result;
        }

        [HttpGet("get-events")]
        public async Task<IActionResult> GetEventsForAdmin([FromQuery] SieveModel sieveModel)
        {
            var apiUrl = _configuration.GetValue<string>("Serilog:WriteTo:3:Args:serverUrl");
            var apiKey = _configuration.GetValue<string>("Serilog:WriteTo:3:Args:apiKey");

            try
            {
                using (var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) })
                {
                    httpClient.DefaultRequestHeaders.Add("X-Seq-ApiKey", apiKey);

                    // Ovde možete promeniti parametre filtera prema vašim potrebama
                    var queryString = "?filter=RequestMethod=='PATCH' or RequestMethod=='DELETE'";
                    var requestUri = "/api/events" + queryString;

                    // Šaljemo GET zahtev ka Seq API-ju
                    var response = await httpClient.GetAsync(requestUri);

                    // Proveravamo odgovor i izvlačimo sadržaj kao string ako je zahtev uspešan
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        // Koristimo JSON deserializaciju za pretvaranje sadržaja u IEnumerable<SeqLogData>
                        // Pretvaramo JSON string u JArray
                        var jsonArray = JArray.Parse(content);
                        List<SeqLogData> lista = new List<SeqLogData>();
                        // Iteriramo kroz svaki JObject u JArray-u
                        foreach (var jObject in jsonArray)
                        {
                            var timestamp = jObject["Timestamp"].Value<DateTime>();
                            var requestedMethod = jObject["Properties"].FirstOrDefault(p => p["Name"].Value<string>() == "RequestMethod")?["Value"].Value<string>();
                            var requestPath = jObject["Properties"].FirstOrDefault(p => p["Name"].Value<string>() == "RequestPath")?["Value"].Value<string>();
                            var statusCode = jObject["Properties"].FirstOrDefault(p => p["Name"].Value<string>() == "StatusCode")?["Value"].Value<string?>();

                            lista.Add(new SeqLogData(timestamp, requestedMethod, requestPath, statusCode));
                        }
                        var sieved = _sieveProcessor.Apply(sieveModel, lista.AsQueryable());
                        SeqLogDataReadDTO final = new SeqLogDataReadDTO(lista.Count, sieved.Count(), sieved.ToList());
                        return Ok(final);
                    }
                    else
                    {
                        Console.WriteLine($"Request failed. Status code: {response.StatusCode}");
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to fetch logs: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(string userId)
        {
            var result = await _mediator.Send(new DeleteUserCommand(userId));
            return Ok(result);
        }

    }
}
