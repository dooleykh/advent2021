using System.Text.RegularExpressions;

using Advent2021.Utilities;

namespace Advent2021.Days;

public class Day8 : Day
{
    private List<string> Input;
    public Day8(IInputParser parser) : base(parser)
    {
        Input = parser.InputToStrings();
    }

    public override object Part1()
    {
        return
            Input
            .Select(entry => Regex.Matches(entry, @"\b\w+\b").Skip(10))
            .SelectMany(matches => matches.Select(m => m.Value))
            .Count(digitSegments => 
                digitSegments.Length == 2 ||
                digitSegments.Length == 4 ||
                digitSegments.Length == 3 ||
                digitSegments.Length == 7);
    }

    public override object Part2()
    {
        List<List<string>> entries = Input
            .Select(entry => Regex.Matches(entry, @"\b\w+\b")
                .Select(m => m.Value))
            .Select(digits => digits.Select(d => {
                char[] segments = d.ToCharArray();
                Array.Sort(segments);
                return new string(segments);
            }).ToList())
            .ToList();

        int sum = 0;
        foreach(List<string> entry in entries)
        {
            Dictionary<int, string> digitMappings = new Dictionary<int, string>() {
                { 1, entry.First(digit => digit.Length == 2) },
                { 4, entry.First(digit => digit.Length == 4) },
                { 7, entry.First(digit => digit.Length == 3) },
                { 8, entry.First(digit => digit.Length == 7) },
            };

            //segment a
            char a = digitMappings[7].Except(digitMappings[1]).First();

            //digit 9
            string nine = entry
                .Take(10)
                .First(e => 
                    ContainsAll(e, digitMappings[4] + a) &&
                    e.Except(digitMappings[4] + a).Count() == 1);
            digitMappings.Add(9, nine);

            //segment e
            char eSeg = digitMappings[8].Except(digitMappings[9]).First();

            //segment g
            char g = digitMappings[9].Except(digitMappings[4])
                .Except(new char[] { a }).First();

            //digit 6
            string six = entry
                .Take(10)
                .Where(e => e.Length == 6)
                .First(e => ContainsAll(e, digitMappings[8].Except(digitMappings[7])));
            digitMappings.Add(6, six);

            //segment c
            char c = digitMappings[8].Except(digitMappings[6]).First();

            //segment f
            char f = digitMappings[1].Except(new char[] { c }).First();

            //digit 3
            string three = entry
                .Take(10)
                .First(e => 
                    ContainsAll(e, digitMappings[1] + a + g) &&
                    e.Except(digitMappings[1]).Except(new char[] { a, g }).Count() == 1);
            digitMappings.Add(3, three);

            //digit 2
            var tempTwo = digitMappings[3]
                .Except(new char[] { f })
                .Concat(new char[] { eSeg })
                .ToArray();
            Array.Sort(tempTwo);
            digitMappings.Add(2, new string(tempTwo));

            //digit 5
            var tempFive = digitMappings[6]
                .Except(new char[] { eSeg })
                .ToArray();
            Array.Sort(tempFive);
            digitMappings.Add(5, new string(tempFive));

            //digit 0
            string zero = entry.Take(10).Except(digitMappings.Values).First();
            digitMappings.Add(0, zero);

            Dictionary<string, int> segmentsToValue = digitMappings
                .Select(kvp => (newKey: kvp.Value, newValue: kvp.Key))
                .ToDictionary(pair => pair.newKey, pair => pair.newValue);

            string s = string.Join("", entry.Skip(10).Select(d => segmentsToValue[d]));
            sum += Convert.ToInt32(s);
        }

        return sum;
    }

    private bool ContainsAll(IEnumerable<char> first, IEnumerable<char> second) => second.All(c => first.Contains(c));
}