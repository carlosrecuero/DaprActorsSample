using DaprActors;

namespace DaprActors.Controllers.Models
{

    public class AssignSeatDto
    {
        public string SeatName { get; init; }
        public PassengerDto Passenger { get; init; }

        //public Seat ToSeat() => Seat.Create(this.SeatName, this.Passenger.ToPassenger());
        public Seat ToSeat() => new Seat()
        {
            SeatName = this.SeatName,
            PassengerFullName = $"{this.Passenger.Name} {this.Passenger.Surname}"
        };
    }
}
