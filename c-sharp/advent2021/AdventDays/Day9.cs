using Advent2021.Utilities;

namespace Advent2021.Days;

public class Day9 : Day
{
    private List<string> Input;
    private int[][] Grid;

    public Day9(IInputParser parser) : base(parser)
    {
        Input = parser.InputToStrings();
        Grid = new int[Input.Count][];
        for (int i = 0; i < Input.Count; i++)
        {
            Grid[i] = Input[i]
                .ToCharArray()
                .Select(c => Convert.ToInt32(c.ToString()))
                .ToArray();
        }
    }

    private List<(int i, int j)> GetValidNeighbors(int i, int j)
    {
        List<(int i, int j)> neighbors = new List<(int, int)>()
        {
            (i - 1, j),
            (i + 1, j),
            (i, j - 1),
            (i, j + 1),
        };

        return neighbors.Where(loc =>
            loc.i >= 0 &&
            loc.i < Grid.Length &&
            loc.j >= 0 &&
            loc.j < Grid[0].Length
        ).ToList();
    }

    public override object Part1()
    {
        int sum = 0;
        for (int i = 0; i < Grid.Length; i++)
            for (int j = 0; j < Grid[0].Length; j++)
            {
                if (GetValidNeighbors(i, j).All(loc => Grid[i][j] < Grid[loc.i][loc.j])) 
                    sum += Grid[i][j] + 1;
            }

        return sum;
    }

    public override object Part2()
    {
        bool[][] visited = new bool[Grid.Length][];
        for (int i = 0; i < visited.Length; i++) visited[i] = new bool[Grid[0].Length];
        for (int i = 0; i < Grid.Length; i++) 
            for (int j = 0; j < Grid[0].Length; j++) 
                visited[i][j] = (Grid[i][j] == 9);
        
        List<int> basinSizes = new List<int>();
        for (int i = 0; i < visited.Length; i++)
            for (int j = 0; j < visited[0].Length; j++)
            {
                if (visited[i][j]) continue;
                int size = 0;
                Queue<(int i, int j)> candidates = new Queue<(int i, int j)>();
                candidates.Enqueue((i, j));

                while (candidates.Count > 0)
                {
                    (int i, int j) curr = candidates.Dequeue();
                    if (visited[curr.i][curr.j]) continue;
                    GetValidNeighbors(curr.i, curr.j)
                    .ForEach(loc => {
                        if (!visited[loc.i][loc.j]) candidates.Enqueue(loc);
                    });
                  
                    size++;
                    visited[curr.i][curr.j] = true;
                }
                basinSizes.Add(size);
            }

        basinSizes.Sort();
        return basinSizes
            .TakeLast(3)
            .Aggregate(
                1,
                (subTotal, basinSize) => subTotal * basinSize);
    }
}