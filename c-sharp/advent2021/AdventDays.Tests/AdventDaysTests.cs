using Xunit;

namespace Advent2021.Days.Tests;

public class AdventDaysTests
{
    [Theory]
    [AdventTestCase(typeof(Day1), "sample-day-1.txt", 7)]
    [AdventTestCase(typeof(Day1), "day-1.txt", 1446)]
    [AdventTestCase(typeof(Day2), "sample-day-2.txt", 150)]
    [AdventTestCase(typeof(Day2), "day-2.txt", 1727835)]
    [AdventTestCase(typeof(Day3), "sample-day-3.txt", 198)]
    [AdventTestCase(typeof(Day3), "day-3.txt", 2640986)]
    [AdventTestCase(typeof(Day4), "sample-day-4.txt", 4512)]
    [AdventTestCase(typeof(Day4), "day-4.txt", 11536)]
    [AdventTestCase(typeof(Day5), "sample-day-5.txt", 5)]
    [AdventTestCase(typeof(Day5), "day-5.txt", 6710)]
    [AdventTestCase(typeof(Day6), "sample-day-6.txt", 5934L)]
    [AdventTestCase(typeof(Day6), "day-6.txt", 359999L)]
    [AdventTestCase(typeof(Day7), "sample-day-7.txt", 37)]
    [AdventTestCase(typeof(Day7), "day-7.txt", 337833)]
    [AdventTestCase(typeof(Day8), "sample-day-8.txt", 26)]
    [AdventTestCase(typeof(Day8), "day-8.txt", 310)]
    [AdventTestCase(typeof(Day9), "sample-day-9.txt", 15)]
    [AdventTestCase(typeof(Day9), "day-9.txt", 480)]
    [AdventTestCase(typeof(Day10), "sample-day-10.txt", 26397)]
    [AdventTestCase(typeof(Day10), "day-10.txt", 374061)]
    public void Part1Tests(Day day, object expectedResult) => Assert.Equal(expectedResult, day.Part1());

    [Theory]
    [AdventTestCase(typeof(Day1), "sample-day-1.txt", 5)]
    [AdventTestCase(typeof(Day1), "day-1.txt", 1486)]
    [AdventTestCase(typeof(Day2), "sample-day-2.txt", 900)]
    [AdventTestCase(typeof(Day2), "day-2.txt", 1544000595)]
    [AdventTestCase(typeof(Day3), "sample-day-3.txt", 230)]
    [AdventTestCase(typeof(Day3), "day-3.txt", 6822109)]
    [AdventTestCase(typeof(Day4), "sample-day-4.txt", 1924)]
    [AdventTestCase(typeof(Day4), "day-4.txt", 1284)]
    [AdventTestCase(typeof(Day5), "sample-day-5.txt", 12)]
    [AdventTestCase(typeof(Day5), "day-5.txt", 20121)]
    [AdventTestCase(typeof(Day6), "sample-day-6.txt", 26984457539L)]
    [AdventTestCase(typeof(Day6), "day-6.txt", 1631647919273L)]
    [AdventTestCase(typeof(Day7), "sample-day-7.txt", 168)]
    [AdventTestCase(typeof(Day7), "day-7.txt", 96678050)]
    [AdventTestCase(typeof(Day8), "sample-day-8.txt", 61229)]
    [AdventTestCase(typeof(Day8), "day-8.txt", 915941)]
    [AdventTestCase(typeof(Day9), "sample-day-9.txt", 1134)]
    [AdventTestCase(typeof(Day9), "day-9.txt", 1045660)]
    [AdventTestCase(typeof(Day10), "sample-day-10.txt", 288957L)]
    [AdventTestCase(typeof(Day10), "day-10.txt", 2116639949L)]
    public void Part2Tests(Day day, object expectedResult) => Assert.Equal(expectedResult, day.Part2());
}