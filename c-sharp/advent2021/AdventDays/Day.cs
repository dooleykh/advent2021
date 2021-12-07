using Advent2021.Utilities;

namespace Advent2021.Days;

public abstract class Day {

    protected IInputParser Parser { get; set; }

    public Day(IInputParser parser) {
        Parser = parser;
    }

    public abstract object Part1();
    
    public abstract object Part2();
}
