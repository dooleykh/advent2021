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
    public void Part2Tests(Day day, object expectedResult) => Assert.Equal(expectedResult, day.Part2());
}