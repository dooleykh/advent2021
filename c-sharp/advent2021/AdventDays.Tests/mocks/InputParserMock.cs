using System.Collections.Generic;
using Advent2021.Utilities;

namespace AdventDays.Tests;

public class InputParserMock : IInputParser 
{
    public string? ToStringValue { get; set; }
    public List<float>? ToNumsValue { get; set; }

    public string InputToString() => ToStringValue ?? "VALUE NOT SET IN MOCK";

    public List<float> InputToNums()
    {
        if (ToNumsValue ==  null) throw new System.Exception();
        return ToNumsValue;
    }
}
