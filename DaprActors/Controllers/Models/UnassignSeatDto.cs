namespace DaprActors.Controllers.Models
{
    public class UnassignSeatDto
    {
        public string SeatName { get; init; }

        //public Seat ToSeat() => Seat.Create(this.SeatName);
        public Seat ToSeat() => new Seat() { SeatName = this.SeatName };
    }
}
