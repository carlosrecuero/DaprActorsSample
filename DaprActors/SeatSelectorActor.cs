using Dapr.Actors.Runtime;
using Dapr.Client;

namespace DaprActors
{
    public class SeatSelectorActor : Actor, ISeatSelectorActor
    {
        public const string STATE_NAME = "redis-state";
        private const string FLIGHT_KEY = "Flight";
        private const string SEAT_BOOKING_KEY = "Seat";
        private readonly DaprClient _daprClient;
        private Flight? _flight { get; set; }

        public SeatSelectorActor(ActorHost host, DaprClient daprClient) : base(host)
        {
            _daprClient = daprClient;

        }

        protected override async Task OnActivateAsync()
        {
            var flightNumber = this.Id.GetId();
            _flight = await _daprClient.GetStateAsync<Flight>(STATE_NAME, flightNumber);
            await base.OnActivateAsync();
        }
        private string GetSeatBookingStateName(Seat seat) => $"{SEAT_BOOKING_KEY}_{seat.SeatName}";

        public async Task AssignSeat(Seat seat)
        {
            //if (!IsValidSeat(seat)) return;

            //var seatBookingStateName = GetSeatBookingStateName(seat);
            await this.StateManager.SetStateAsync(seat.SeatName, seat);
        }

        public async Task UnassignSeat(Seat seat)
        {
            //if (!IsValidSeat(seat)) return;

            //var seatBookingStateName = GetSeatBookingStateName(seat);
            await this.StateManager.RemoveStateAsync(seat.SeatName);
        }

        public async Task<Seat> GetSeat(string seatName)
        {
            var state = await this.StateManager.TryGetStateAsync<Seat>(seatName);
            return state.HasValue ? state.Value : null;
        }

        //private bool IsValidSeat(Seat seat) => _flight!.Has(seat);

        //Reminder: habría que borrar o bloquear todos los asientos al comenzar el vuelo o la fecha de despegue
    }
}
