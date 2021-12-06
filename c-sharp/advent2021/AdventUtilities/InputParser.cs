namespace Advent2021.Utilities;

public class InputParser : IInputParser 
{
    public readonly StreamReader Reader;

    public InputParser(Stream stream)
    {
        Reader = new StreamReader(stream);
    }

    public string InputToString() => Reader.ReadToEnd();

    public List<float> InputToNums() 
    {
        List<float> nums = new List<float>();
        while (true)
        {
            string? line = Reader.ReadLine();
            if (string.IsNullOrEmpty(line)) break;
            nums.Add(Convert.ToSingle(line));
        }

        return nums;
    }
}
