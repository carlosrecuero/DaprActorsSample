using Dapr.Actors;
using Dapr.Actors.Client;
using Dapr.Client;
using DaprActors.Controllers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DaprActors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {

        private readonly ILogger<SeatsController> _logger;
        private readonly IActorProxyFactory _actorProxyFactory;

        public SeatsController(IActorProxyFactory actorProxyFactory, ILogger<SeatsController> logger)
        {
            _actorProxyFactory = actorProxyFactory;
            _logger = logger;
        }

        [HttpPost("~/flights/{flightNumber}/seats")]
        public async Task AssignSeat([FromRoute]string flightNumber, [FromBody]AssignSeatDto seatDto)
        {
            var seatSelectorActor = _actorProxyFactory.CreateActorProxy<ISeatSelectorActor>(
                new ActorId(flightNumber),
                nameof(SeatSelectorActor));

            await seatSelectorActor.AssignSeat(seatDto.ToSeat());
        }

        [HttpDelete("~/flights/{flightNumber}/seats")]
        public async Task UnassignSeat([FromRoute] string flightNumber, [FromBody] UnassignSeatDto seatDto)
        {
            var seatSelectorActor = _actorProxyFactory.CreateActorProxy<ISeatSelectorActor>(
                new ActorId(flightNumber),
                nameof(SeatSelectorActor));

            await seatSelectorActor.UnassignSeat(seatDto.ToSeat());
        }

        [HttpGet("~/flights/{flightNumber}/seats/{seatName}")]
        public async Task<ActionResult<Seat>> UnassignSeat([FromRoute] string flightNumber, [FromRoute] string seatName)
        {
            var seatSelectorActor = _actorProxyFactory.CreateActorProxy<ISeatSelectorActor>(
                new ActorId(flightNumber),
                nameof(SeatSelectorActor));

            var seat = await seatSelectorActor.GetSeat(seatName);
            return seat is not null ?
                Ok(seat) :
                NotFound();
        }
    }
}
