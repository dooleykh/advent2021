namespace Advent2021.Utilities;

public interface IInputParser {
    public string InputToString();

    public List<float> InputToNums();

    public List<string> InputToStrings();

    public List<string> RawInput();
}
