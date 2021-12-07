using System.Reflection;

using Advent2021.Inputs;
using Advent2021.Days;
using Advent2021.Utilities;

if (args.Length != 2) throw new ArgumentException("Arg 1: Day. Arg 2: Part.");

IInputParser parser = new InputParser(AdventInputs.GetPuzzleInput(args[0]));

Day day = args[0] switch
{
    "1" => new Day1(parser),
    "2" => new Day2(parser),
    "3" => new Day3(parser),
    "4" => new Day4(parser),
    _ => throw new NotImplementedException()
};

Console.WriteLine(
    args[1] switch {
        "1" => day.Part1(),
        "2" => day.Part2(),
        _ => throw new ArgumentException()
    }
);
