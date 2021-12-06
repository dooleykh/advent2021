using Advent2021.Utilities;
namespace Advent2021.Days;

public class Day1 : Day {

    private IEnumerable<float> Input;

    public Day1(IInputParser parser) : base(parser)
    {
        Input = Parser.InputToNums();
    }

    public override object Part1() 
    {
        int increases = 0;
        while (Input.Count() > 1)
        {
            if (Input.ElementAt(1) > Input.ElementAt(0)) increases++;

            Input = Input.Skip(1);
        }

        return increases;
    }

    public override object Part2() 
    {
        int increases = 0;
        while (Input.Count() > 3)
        {
            if (Input.Take(3).Sum() < Input.Skip(1).Take(3).Sum()) increases++;

            Input = Input.Skip(1);
        }

        return increases;
    }
}
