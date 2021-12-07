using System.Text.RegularExpressions;

using Advent2021.Utilities;

namespace Advent2021.Days;

public class Day2 : Day {

    private IEnumerable<string> Input;

    public Day2(IInputParser parser) : base(parser)
    {
        Input = Parser.InputToStrings();
    }

    public override object Part1() 
    {
        int horizontal = 0, vertical = 0;
        foreach(string move in Input)
        {
            string[] split = Regex.Split(move, @"\s+");
            int value = Convert.ToInt32(split[1]);
            switch (split[0])
            {
                case "forward":
                    horizontal += value;
                    break;
                case "down":
                    vertical += value;
                    break;
                case "up":
                    vertical -= value;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        return horizontal * vertical;
    }

    public override object Part2() 
    {
        int horizontal = 0, vertical = 0, aim = 0;
        foreach(string move in Input)
        {
            string[] split = Regex.Split(move, @"\s+");
            int value = Convert.ToInt32(split[1]);
            switch (split[0])
            {
                case "forward":
                    horizontal += value;
                    vertical += aim * value;
                    break;
                case "down":
                    aim += value;
                    break;
                case "up":
                    aim -= value;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        return horizontal * vertical;
    }
}
