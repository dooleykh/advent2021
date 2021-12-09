using Advent2021.Utilities;

namespace Advent2021.Days;

public class Day7 : Day
{
    private List<int> Input;

    public Day7(IInputParser parser) : base(parser)
    {
        Input = parser
            .InputToString()
            .Split(',')
            .Select(pos => Convert.ToInt32(pos))
            .ToList();
    }

    public override object Part1()
    {
        int minFuel = int.MaxValue;
        int minPosition = Input.Min();
        int maxPosition = Input.Max();
        
        for (int currPos = minPosition; currPos <= maxPosition; currPos++)
        {
            minFuel = Math.Min(
                Input.Select(pos => Math.Abs(pos - currPos)).Sum(),
                minFuel);
        }

        return minFuel;
    }

    public override object Part2()
    {
        int minFuel = int.MaxValue;
        int minPosition = Input.Min();
        int maxPosition = Input.Max();
        
        for (int currPos = minPosition; currPos <= maxPosition; currPos++)
        {
            minFuel = Math.Min(
                Input.Select(pos => Sum1ToN(Math.Abs(pos - currPos))).Sum(),
                minFuel);
        }

        return minFuel;
    }

    private int Sum1ToN(int i) => (i * (i + 1)) / 2;
}