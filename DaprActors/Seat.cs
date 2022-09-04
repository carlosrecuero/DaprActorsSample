using FluentAssertions;
using System.Text.RegularExpressions;

namespace DaprActors
{

    //public record Seat
    //{
    //    public RowId RowId { get; init; }
    //    public LineId LineId { get; init; }
    //    public Passenger? Passenger { get; set; }

    //    private static readonly string _seatPattern = @"(?<Row>\d)(?<Line>\w)";
    //    //private static readonly Regex _seatRegEx = new(@"(?<Row>d+)(?<Line>w)");

    //    public Seat() { }
    //    private Seat(RowId rowId, LineId lineId, Passenger? passenger)
    //    {
    //        RowId = rowId;
    //        LineId = lineId;
    //        Passenger = passenger;
    //    }
    //    public static Seat Create(string seatName, Passenger? passenger = null)
    //    {
    //        var (rowId, lineId) = Seat.FromSeatName(seatName);
    //        return new(rowId!, lineId!, passenger);
    //    }

    //    private static (RowId, LineId) FromSeatName(string seatName)
    //    {
    //        var match = Regex.Match(seatName, _seatPattern);
    //        match.Success.Should().BeTrue();

    //        var rowId = RowId.FromNumber(int.Parse(match!.Groups["Row"].Value));
    //        var lineId = LineId.FromLetter(char.Parse(match!.Groups["Line"].Value));
    //        return (rowId, lineId);
    //    }

    //    public override string ToString() => $"{RowId}{LineId}";
    //    public void Assign(Passenger passenger) => Passenger = passenger;
    //    public void Unassign() => Passenger = null;
    //    public bool IsAssigned() => Passenger is not null;
    //}

    //public record Passenger(string Name, string Surname, string IdCardNumber)
    //{
    //    public string FullName = $"{Surname},{Name}".ToUpper();
    //}

    public record Seat
    {
        public string SeatName { get; set; }
        public string PassengerFullName { get; set; }
    }
}
