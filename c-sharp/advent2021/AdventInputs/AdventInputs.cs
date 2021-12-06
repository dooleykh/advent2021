using System.IO;
using System.Reflection;

namespace Advent2021.Inputs;
public static class AdventInputs
{
    public static Stream GetPuzzleInput(string day)
    {
        Stream? resource = 
            Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream($"AdventInputs.day-{day}.txt");
        if (resource == null) throw new FileNotFoundException($"Missing resource file for file");

        return resource;
    }

    public static Stream GetSamplePuzzleInput(string fileName)
    {
        Stream? resource = 
            Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream($"AdventInputs.{fileName}");
        if (resource == null) throw new FileNotFoundException($"Missing resource file for file {fileName}");

        return resource;
    }
}
