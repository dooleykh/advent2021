using Advent2021.Days;
using Advent2021.Inputs;
using Advent2021.Utilities;

if (args.Length != 2) throw new ArgumentException("Arg 1: Day. Arg 2: Part.");

Type? t = Type.GetType($"Advent2021.Days.Day{args[0]}, AdventDays");
if (t is null) throw new ArgumentException("Unknown Day");

Day? day = Activator.CreateInstance(
    t,
    new object[] { new InputParser(AdventInputs.GetPuzzleInput(args[0])) }) as Day;
if (day is null) throw new InvalidOperationException($"Could not create instance of Day{args[0]}");

Console.WriteLine(
    args[1] switch {
        "1" => day.Part1(),
        "2" => day.Part2(),
        _ => throw new ArgumentException()
    }
);
