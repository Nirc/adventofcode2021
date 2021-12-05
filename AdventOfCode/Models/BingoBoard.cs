namespace AdventOfCode.Models;

public class BingoBoard
{
    private BingoBoardSpot[,] _boardSpots;

    public BingoBoard(int[,] boardNumbers)
    {
        _boardSpots = new BingoBoardSpot[boardNumbers.GetLength(0), boardNumbers.GetLength(1)];

        for(int x = 0; x < boardNumbers.GetLength(0); x++)
        {
            for(int y = 0; y < boardNumbers.GetLength(1); y++)
            {
                _boardSpots[x, y] = new BingoBoardSpot { Value = boardNumbers[x, y], Marked = false };
            }
        }
    }

    public void MarkNumber(int value)
    {
        foreach(var spot in _boardSpots)
        {
            if (spot.Value == value)
            {
                spot.Marked = true;
            }
        }
    }

    public int CalculateScore(int mostRecentCallout)
    {
        int score = 0;
        foreach(var spot in _boardSpots)
        {
            if (!spot.Marked) { score += spot.Value; }
        }

        return score * mostRecentCallout;
    }

    public bool HasBingo
    {
        get
        {
            for(int i = 0; i < _boardSpots.GetLength(0); i++)
            {
                if (RowHasBingo(i)) { return true; }
            }

            for (int i = 0; i < _boardSpots.GetLength(1); i++)
            {
                if (ColumnHasBingo(i)) { return true; }
            }

            return false;
        }
    }

    private bool RowHasBingo(int rowIndex)
    {
        for(int i = 0; i < _boardSpots.GetLength(1); i++)
        {
            var spot = _boardSpots[rowIndex, i];
            if (!spot.Marked) { return false; }
        }

        return true;
    }

    private bool ColumnHasBingo(int columnIndex)
    {
        for (int i = 0; i < _boardSpots.GetLength(1); i++)
        {
            var spot = _boardSpots[i, columnIndex];
            if (!spot.Marked) { return false; }
        }

        return true;
    }
}
