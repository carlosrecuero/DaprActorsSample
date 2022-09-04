namespace DaprActors.Controllers.Models
{
    public class PassengerDto
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public string IdCardNumber { get; init; }

        //public Passenger ToPassenger() => new Passenger(this.Name, this.Surname, this.IdCardNumber);
    }
}
