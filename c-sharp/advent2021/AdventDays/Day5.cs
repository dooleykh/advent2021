using System.Text.RegularExpressions;

using Advent2021.Utilities;

namespace Advent2021.Days;

public class Day5 : Day
{
    private List<string> Input;
    private List<Line> Lines;
    private int maxX = 0, maxY = 0;
    private int[][] Grid;

    public Day5(IInputParser parser) : base(parser)
    {
        Input = parser.InputToStrings();
        Lines = new List<Line>();
        foreach(string row in Input)
        {
            Match match = Regex.Match(row, @"^(\d+),(\d+) -> (\d+),(\d+)$");
            
            int p1X = Convert.ToInt32(match.Groups[1].Value);
            int p1Y = Convert.ToInt32(match.Groups[2].Value);
            int p2X = Convert.ToInt32(match.Groups[3].Value);
            int p2Y = Convert.ToInt32(match.Groups[4].Value);
            
            Lines.Add(new Line() 
            {
                P1 = (p1X, p1Y),
                P2 = (p2X, p2Y)
            });

            maxX = Math.Max(maxX, Math.Max(p1X, p2X));
            maxY = Math.Max(maxY, Math.Max(p1Y, p2Y));
        }
        maxX++;
        maxY++;
        Grid = new int[maxY][];
        for (int i = 0; i < maxY; i++) Grid[i] = new int[maxX];
    }

    public override object Part1()
    {
        foreach(Line line in Lines)
        {
            if (line.P1.x != line.P2.x && line.P1.y != line.P2.y) continue;
            foreach ((int i, int j) in line.Coverage())
            {
                Grid[j][i] += 1;
            }
        }

        return Grid.SelectMany(row => row).Count(point => point > 1);
    }

    public override object Part2()
    {
        foreach(Line line in Lines)
        {
            foreach ((int i, int j) in line.Coverage())
            {
                Grid[j][i] += 1;
            }
        }

        return Grid.SelectMany(row => row).Count(point => point > 1);
    }
}

record Line
{
    public (int x, int y) P1;
    public (int x, int y) P2;

    public List<(int x, int y)> Coverage()
    {
        List<(int x, int y)> points = new List<(int x, int y)>();
        if (P1.x == P2.x)
        {
            for (int i = Math.Min(P1.y, P2.y); i <= Math.Max(P1.y, P2.y); i++)
            {
                points.Add((P1.x, i));
            }
        }
        else if (P1.y == P2.y)
        {
            for (int i = Math.Min(P1.x, P2.x); i <= Math.Max(P1.x, P2.x); i++)
            {
                points.Add((i, P1.y));
            }
        }
        else
        {
            (int x, int y) start, end;
            if (P1.x < P2.x)
            {
                start = P1;
                end = P2;
            }
            else
            {
                start = P2;
                end = P1;
            }

            (int x, int y) = start;
            if (start.y < end.y)
            {
                while (y <= end.y)
                {
                    points.Add((x, y));
                    x++;
                    y++;
                }
            }
            else
            {
                while (y >= end.y)
                {
                    points.Add((x, y));
                    x++;
                    y--;
                }
            }
        }

        return points;
    }
}
