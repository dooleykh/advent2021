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
    public void Part1Tests(Day day, object expectedResult) => Assert.Equal(expectedResult, day.Part1());

    [Theory]
    [AdventTestCase(typeof(Day1), "sample-day-1.txt", 5)]
    [AdventTestCase(typeof(Day1), "day-1.txt", 1486)]
    [AdventTestCase(typeof(Day2), "sample-day-2.txt", 900)]
    [AdventTestCase(typeof(Day2), "day-2.txt", 1544000595)]
    [AdventTestCase(typeof(Day3), "sample-day-3.txt", 230)]
    [AdventTestCase(typeof(Day3), "day-3.txt", 6822109)]
    public void Part2Tests(Day day, object expectedResult) => Assert.Equal(expectedResult, day.Part2());
}