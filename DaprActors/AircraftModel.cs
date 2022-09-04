using FluentAssertions;

namespace DaprActors
{
    //public record AircraftModel
    //{
    //    public static AircraftModel Boeing747 = new(nameof(Boeing747), 35, 8);
    //    public static AircraftModel Boeing757 = new(nameof(Boeing757), 55, 8);
    //    public static AircraftModel AirbusA320 = new(nameof(AirbusA320), 50, 10);

    //    public string Name { get; init; } 
    //    public int Rows { get; init; }
    //    public int Lines { get; init; }

    //    public AircraftModel(string name, int rows, int lines)
    //    {
    //        rows.Should().BePositive();
    //        lines.Should().BePositive();

    //        Name = name;
    //        Rows = rows;
    //        Lines = lines;
    //    }


    //    private static IEnumerable<AircraftModel> GetAll()
    //    {
    //        yield return Boeing747;
    //        yield return Boeing757;
    //        yield return AirbusA320;
    //    }

    //    public static AircraftModel GetByNameOrThrow(string name) => GetAll().ToDictionary(x => x.Name)[name];

    //    public bool Has(Seat seat)
    //    {
    //        return seat.RowId <= RowId.FromNumber(this.Rows)
    //            && seat.LineId <= LineId.FromNumber(this.Lines);
    //    }
    //}
}
