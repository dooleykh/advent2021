using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Xunit.Sdk;

using Advent2021.Inputs;
using Advent2021.Utilities;

namespace Advent2021.Days.Tests;

public class AdventTestCaseAttribute : DataAttribute
{

    private readonly Day? InputDay;
    private readonly object ExpectedResult;

    public AdventTestCaseAttribute(Type type, string fileName, object expectedResult)
    {
        Stream resource = AdventInputs.GetSamplePuzzleInput(fileName);
        InputDay = Activator.CreateInstance(
            type,
            new object[] { new InputParser(resource) }) as Day;
        if (InputDay is null) throw new ArgumentException();
        ExpectedResult = expectedResult;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        if (testMethod is null) throw new System.Exception();

        return new List<object[]>() { new object[] { InputDay!, ExpectedResult }};
    }
}