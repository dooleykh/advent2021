using Advent2021.Utilities;

namespace Advent2021.Days;

public class Day6 : Day
{
    private long[] Input;

    public Day6(IInputParser parser) : base(parser)
    {
        Input = new long[9];
        parser
            .InputToString()
            .Split(',')
            .Select(fishTimer => Convert.ToInt64(fishTimer))
            .ToList()
            .ForEach(fishTimer => Input[fishTimer] += 1);
    }

    public override object Part1()
    {
        foreach(var _ in Enumerable.Range(0, 80)) NextDay(Input);
        return Input.Sum();
    }

    public override object Part2()
    {
        foreach(var _ in Enumerable.Range(0, 256)) NextDay(Input);
        return Input.Sum();
    }

    private void NextDay(long[] fishTimers)
    {
        long zeroTimers = Input[0];
        for (int j = 0; j < Input.Length - 1; j++) Input[j] = Input[j + 1];
        Input[6] += zeroTimers;
        Input[8] = zeroTimers;
    }
}