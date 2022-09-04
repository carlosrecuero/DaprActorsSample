using FluentAssertions;

namespace DaprActors
{
    //public record Flight
    //{
    //    public string Number { get; init; }
    //    public AircraftModel AircraftModel { get; init; }

    //    public Flight(string number, string aircraftModelName)
    //    {
    //        var aircraftModel = AircraftModel.GetByNameOrThrow(aircraftModelName);

    //        Number = number;
    //        AircraftModel = aircraftModel;
    //    }

    //    public bool Has(Seat seat) => this.AircraftModel.Has(seat);
    //}

    public record Flight
    {
        public string Number { get; init; }
        public string AircraftModelName { get; init; }

    }
}
