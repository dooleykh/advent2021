using Advent2021.Utilities;

namespace Advent2021.Days;

public class Day10 : Day
{
    private List<string> Input;

    public Day10(IInputParser parser) : base(parser)
    {
        Input = parser.InputToStrings();
    }

    public bool IsInvalid(string line, out char? invalidChar, ref Stack<char> stack)
    {
        List<char> openings = new List<char>() { '(', '[', '{', '<' };

        Dictionary<char, char> closingMappings =
            new Dictionary<char, char>() {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' },
                { '>', '<' },
            };

        stack = new Stack<char>();
        foreach (char c in line)
        {
            if (openings.Contains(c)) stack.Push(c);
            else 
            {
                if (stack.Count == 0 || stack.Peek() != closingMappings[c])
                {
                    invalidChar = c;
                    return true;
                }
                else stack.Pop();
            }
        }
        
        invalidChar = null;
        return false;
    }

    public override object Part1()
    {   
        int points = 0;
        foreach (string s in Input)
        {
            Stack<char> stack = null!;
            if (IsInvalid(s, out char? c, ref stack!))
            {
                points += (c!) switch
                {
                    ')' => 3,
                    ']' => 57,
                    '}' => 1197,
                    '>' => 25137,
                    _ => throw new Exception()
                };
            }
        }

        return points;
    }

    public override object Part2()
    {
        List<long> pointTotals = new List<long>();
        foreach (string s in Input)
        {
            Stack<char> stack = null!;
            if (IsInvalid(s, out char? _, ref stack)) continue;
            
            long points = 0;
            while (stack.Count != 0)
            {
                char c = stack.Pop();
                points = points * 5 + 
                    (c switch {
                        '(' => 1, 
                        '[' => 2, 
                        '{' => 3, 
                        '<' => 4,
                        _ => throw new Exception()
                    });
            }

            pointTotals.Add(points);
        }

        pointTotals.Sort();
        return pointTotals.Skip(pointTotals.Count / 2).First();
    }
}