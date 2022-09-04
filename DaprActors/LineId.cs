using FluentAssertions;

namespace DaprActors
{
    public class LineId
    {
        private char _value;

        private static readonly char[] LINE_NAMES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private LineId(char value)
        {
            value.Should().BeInRange('A', 'Z');
            _value = value;
        }
        public static LineId FromLetter(char letter) => new(letter);
        public static LineId FromNumber(int lineNumber)
        {
            lineNumber.Should().BeInRange(1, LINE_NAMES.Length);
            return new(LINE_NAMES[lineNumber - 1]);
        }
        public override string ToString() => _value.ToString();

        public static bool operator <=(LineId a, LineId b) => a._value <= b._value;
        public static bool operator >=(LineId a, LineId b) => a._value >= b._value;
    }
}
