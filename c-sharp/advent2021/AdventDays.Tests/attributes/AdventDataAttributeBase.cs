using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Xunit.Sdk;

using Advent2021.Inputs;
using Advent2021.Utilities;

namespace AdventDays.Tests;


public class AdventTestCaseAttribute : DataAttribute
{

    private InputParser Parser;
    private object ExpectedResult;

    public AdventTestCaseAttribute(string fileName, object expectedResult)
    {
        Stream? resource = AdventInputs.GetSamplePuzzleInput(fileName);
        Parser = new InputParser(resource);
        ExpectedResult = expectedResult;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        if (testMethod is null) throw new System.Exception();

        return new List<object[]>() { new object[] { Parser, ExpectedResult }};
    }
}