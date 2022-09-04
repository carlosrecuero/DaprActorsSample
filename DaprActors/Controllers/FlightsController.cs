using Dapr.Actors;
using Dapr.Actors.Client;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace DaprActors.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly DaprClient _daprClient;
        private readonly ILogger<FlightsController> _logger;
        private readonly string _stateStoreName = "redis-state";
        private readonly IActorProxyFactory _actorProxyFactory;
        public FlightsController(IActorProxyFactory actorProxyFactory, DaprClient daprClient, ILogger<FlightsController> logger)
        {
            _actorProxyFactory = actorProxyFactory;
            _daprClient = daprClient;
            _logger = logger;
        }

        [HttpPost]
        public async Task CreateFlight(string flightNumber, string aircraftModelName, string departureAirportCode, DateTime departureDate)
        {
            var flight = new Flight()
            {
                Number = flightNumber,
                AircraftModelName = aircraftModelName
            };
            await _daprClient.SaveStateAsync<Flight>(_stateStoreName, flight.Number, flight);
            _actorProxyFactory.CreateActorProxy<ISeatSelectorActor>(
                new ActorId(flightNumber),
                nameof(SeatSelectorActor));
        }

    }
}