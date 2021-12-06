using Xunit;

using Advent2021.Days;
using Advent2021.Utilities;

namespace AdventDays.Tests;

public class Day1Test
{
    [Theory]
    [AdventTestCase("sample-day-1.txt", 7)]
    [AdventTestCase("day-1.txt", 1446)]
    public void Part1(IInputParser parserMock, int expectedCount)
    {
        Day1 day = new Day1(parserMock);
        Assert.Equal(expectedCount, day.Part1());
    }

    [Theory]
    [AdventTestCase("sample-day-1.txt", 5)]
    [AdventTestCase("day-1.txt", 1486)]
    public void Part2(IInputParser parserMock, int expectedCount)
    {
        Day1 day = new Day1(parserMock);
        Assert.Equal(expectedCount, day.Part2());
    }
}
