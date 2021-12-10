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
        List<(int i, int j)> neighbors = new List<(int i, int j)>()
        {
            (i: i - 1, j: j),
            (i: i + 1, j: j),
            (i: i, j: j - 1),
            (i: i, j: j + 1),
        };

        return neighbors.Where(loc =>
            loc.i >= 0 &&
            loc.i < Grid.Length &&
            loc.j >= 0 &&
            loc.j < Grid[0].Length
        ).ToList();
    }
    
    private bool IsLowPoint(int i, int j)
    {
        int height = Grid[i][j];
        var (up, down, left, right) = (
            (i: i - 1, j: j),
            (i: i + 1, j: j),
            (i: i, j: j - 1),
            (i: i, j: j + 1)
        );
        
        if (up.i >= 0 && Grid[up.i][up.j] <= height) return false;
        if (down.i < Grid.Length && Grid[down.i][down.j] <= height) return false;
        if (left.j >= 0 && Grid[left.i][left.j] <= height) return false;
        if (right.j < Grid[0].Length && Grid[right.i][right.j] <= height) return false;

        return true;
    }

    public override object Part1()
    {
        int sum = 0;

        for (int i = 0; i < Grid.Length; i++)
        {
            for (int j = 0; j < Grid[0].Length; j++)
            {
                if (IsLowPoint(i, j)) 
                    sum += Grid[i][j] + 1;
            }
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
                List<(int i, int j)> candidates = new List<(int i, int j)>() { (i, j) };
                while (candidates.Count > 0)
                {
                    (int i, int j) curr = candidates[0];
                    if (visited[curr.i][curr.j])
                    {
                        candidates = candidates.Skip(1).ToList();
                        continue;
                    }

                    candidates = candidates
                        .Skip(1)
                        .Concat(
                            GetValidNeighbors(curr.i, curr.j)
                            .Where(loc => !visited[loc.i][loc.j]))
                        .ToList();
                    
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