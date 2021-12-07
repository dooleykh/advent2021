using System.Text.RegularExpressions;
using System.Linq;

using Advent2021.Utilities;

namespace Advent2021.Days;

public class Day4 : Day {

    private List<string> Input;
    private IEnumerable<int> DrawnNumbers;
    private List<Board> Boards = new List<Board>();

    public Day4(IInputParser parser) : base(parser)
    {
        Input = Parser.RawInput();

        string numbers = Input.Take(1).First();
        DrawnNumbers = numbers.Split(',').Select(s => Convert.ToInt32(s));
        Input = Input.Skip(2).ToList();

        while (Input.Count != 0)
        {
            List<string> rows = Input.Take(5).ToList();
            Boards.Add(new Board(rows));
            Input = Input.Skip(6).ToList();
        }
    }

    public override object Part1() 
    {
        foreach(int drawing in DrawnNumbers)
        {
            Boards.ForEach(b => b.Play(drawing));
            Board? winningBoard = Boards.FirstOrDefault(b => b.IsWinner());
            if (winningBoard is not null) return winningBoard.SumUnplayed() * drawing;
        }

        throw new Exception();
    }

    public override object Part2()
    {
        foreach(int drawing in DrawnNumbers)
        {
            Boards.ForEach(b => b.Play(drawing));
            if (Boards.Count > 1)
            {
                Boards.RemoveAll(b => b.IsWinner());
            }
            else
            {
                Board lastBoard = Boards.First();
                if (lastBoard.IsWinner()) return lastBoard.SumUnplayed() * drawing;
            }
        }

        throw new Exception();
    }
}

class Board
{
    private Square[,] Squares;
    public Board(List<string> rows)
    {
        Squares = new Square[5, 5];
        for(int i = 0; i < 5; i++)
        {
            MatchCollection matches = Regex.Matches(rows[i], @"(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)$");
            for(int j = 0; j < 5; j++)
            {
                Squares[i, j] = new Square(Convert.ToInt32(matches[0].Groups[j + 1].Value));
            }
        }
    }

    public void Play(int number)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (Squares[i, j].Value == number)
                {
                    Squares[i, j].Played = true;
                    break;
                }
            }
        }
    }

    public bool IsWinner()
    {
        for (int i = 0; i < 5; i++)
        {
            if (
                Squares[i, 0].Played &&
                Squares[i, 1].Played &&
                Squares[i, 2].Played &&
                Squares[i, 3].Played &&
                Squares[i, 4].Played) return true;
        }

        for (int j = 0; j < 5; j++)
        {
            if (
                Squares[0, j].Played &&
                Squares[1, j].Played &&
                Squares[2, j].Played &&
                Squares[3, j].Played &&
                Squares[4, j].Played) return true;
        }

        return false;
    }

    public int SumUnplayed()
    {
        int total = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (!Squares[i, j].Played) total += Squares[i, j].Value;
            }
        }

        return total;
    }
}

struct Square
{
    public Square(int value)
    {
        Value = value;
        Played = false;
    }

    public int Value { get; }
    public bool Played { get; set; }
}