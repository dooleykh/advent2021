using Advent2021.Utilities;

namespace Advent2021.Days;

public class Day3 : Day {

    private List<string> Input;

    public Day3(IInputParser parser) : base(parser)
    {
        Input = Parser.InputToStrings();
    }

    public override object Part1() 
    {
        int gamma = 0, epsilon = 0;
        while (Input[0].Length > 0)
        {
            gamma <<= 1;
            epsilon <<= 1;

            if (Input.Count(num => num[0] == '1') > Input.Count / 2) gamma++;
            else epsilon++;

            Input = Input.Select(num => num.Substring(1)).ToList();
        }

        return gamma * epsilon;
    }

    public override object Part2()
    {
        int oxygenRating, co2Rating, i = 0, j = 0;

        List<string> numbers = new List<string>(Input);
        while (numbers.Count > 1)
        {
            char mostCommonBit = 
                numbers.Count(num => num[i] == '1') >= numbers.Count / 2.0 ? '1' : '0';
            
            numbers = numbers.Where(num => num[i] == mostCommonBit).ToList();
            i++;
        }
        oxygenRating = Convert.ToInt32(numbers[0], 2);

        while (Input.Count > 1)
        {
            char leastCommonBit = 
                Input.Count(num => num[j] == '0') <= Input.Count / 2.0 ? '0' : '1';
            
            Input = Input.Where(num => num[j] == leastCommonBit).ToList();
            j++;
        }
        co2Rating = Convert.ToInt32(Input[0], 2);

        return oxygenRating * co2Rating;
    }
}
