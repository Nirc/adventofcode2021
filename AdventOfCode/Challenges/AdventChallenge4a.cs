using AdventOfCode.Models;

namespace AdventOfCode.Challenges;

public class AdventChallenge4a : IAdventChallenge
{
    public string ChallengeNumber => "4a";

    public object PerformChallenge()
    {
        const int boardWidth = 5;
        const int boardHeight = 5;
        const int linesToReadForBoard = 6;

        var challengeData = @"ChallengeData/Challenge4Data.txt";
        var numberCallouts = new List<int>();
        var bingoBoards = new List<BingoBoard>();

        bool readFirstLine = false;
        int linesReadForBoard = 0;
        int currentBoardRow = 0;
        var boardNumbers = new int[boardWidth, boardHeight];

        foreach (string line in File.ReadLines(challengeData))
        {
            if (!readFirstLine)
            {
                numberCallouts = line.Split(',').Select(x => int.Parse(x)).ToList();
                readFirstLine = true;
                continue;
            }

            if (line != string.Empty)
            {
                var lineNumbers = line.Split(' ').Where(x => x != "").Select(x => int.Parse(x)).ToArray();
                for(int i = 0; i < lineNumbers.Count(); i++)
                {
                    boardNumbers[currentBoardRow, i] = lineNumbers[i];
                }
                currentBoardRow++;
            }

            linesReadForBoard++;

            if (linesReadForBoard == linesToReadForBoard)
            {
                var board = new BingoBoard(boardNumbers);
                bingoBoards.Add(board);

                boardNumbers = new int[boardWidth, boardHeight];
                linesReadForBoard = 0;
                currentBoardRow = 0;
            }
        }

        var bingoWin = PlayBingo(bingoBoards, numberCallouts);
        if (bingoWin == null) { throw new Exception("No winning boards"); }

        return bingoWin.WinningBoard.CalculateScore(bingoWin.MostRecentCallout);
    }

    private BingoWin PlayBingo(IEnumerable<BingoBoard> boards, IEnumerable<int> numberCallouts)
    {
        foreach (var numberCallout in numberCallouts)
        {
            foreach (var board in boards)
            {
                board.MarkNumber(numberCallout);
                if (board.HasBingo)
                {
                    return new BingoWin { WinningBoard = board, MostRecentCallout = numberCallout };
                }
            }
        }

        return null;
    }
}