using System.Text.RegularExpressions;

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
            int ones = 0;

            ones = Input.Select(num => num[0]).Count(bit => bit == '1');
            if (ones > Input.Count / 2) gamma++;
            else epsilon++;

            Input = Input.Select(num => num.Substring(1)).ToList();
        }

        return gamma * epsilon;
    }

    public override object Part2() 
    {
        int oxygenRating = 0, co2Rating = 0, i = 0;

        List<string> numbers = Input.Take(Input.Count).ToList();
        while (numbers.Count > 1)
        {
            char mostCommonBit = (numbers
                .Count(num => num[i] == '1') >= numbers.Count / 2.0) ? '1' : '0';

            numbers = numbers
                .Where(num => num[i] == mostCommonBit)
                .ToList();
            i++;
        }
        oxygenRating = Convert.ToInt32(numbers[0], 2);
        
        i = 0;
        while (Input.Count > 1)
        {
            char leastCommonBit = (Input
                .Count(num => num[i] == '0') <= Input.Count / 2.0) ? '0' : '1';

            Input = Input
                .Where(num => num[i] == leastCommonBit)
                .ToList();
            i++;
        }
        co2Rating = Convert.ToInt32(Input[0], 2);

        return oxygenRating * co2Rating;
    }
}
