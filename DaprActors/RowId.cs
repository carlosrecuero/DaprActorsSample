using FluentAssertions;

namespace DaprActors
{
    public class RowId
    {
        private int _value;
        private RowId(int value)
        {
            value.Should().BePositive();
            _value = value;
        }
        public static RowId FromNumber(int rowNumber) => new(rowNumber);
        public override string ToString() => _value.ToString();
        public static bool operator <=(RowId a, RowId b) => a._value <= b._value;
        public static bool operator >=(RowId a, RowId b) => a._value >= b._value;

    }
}
