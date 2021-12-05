using AdventOfCode.Models;

namespace AdventOfCode.Challenges;

public class AdventChallenge4b : IAdventChallenge
{
    public string ChallengeNumber => "4b";

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
                for (int i = 0; i < lineNumbers.Count(); i++)
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

        IEnumerable<BingoWin> mostRecentBingoWins = null;
        int winningBoardCount = 0;
        int totalBoardCount = bingoBoards.Count;
        int calloutIndex = 0;
        while (winningBoardCount < totalBoardCount - 1)
        {
            var wins = PlayBingo(bingoBoards, numberCallouts[calloutIndex]);
            if (wins.Count() > 0) { mostRecentBingoWins = wins; }

            calloutIndex++;
            if (calloutIndex > numberCallouts.Count() - 1)
            {
                break;
            }

            if (mostRecentBingoWins != null)
            {
                bingoBoards = bingoBoards.Except(mostRecentBingoWins.Select(x => x.WinningBoard)).ToList();
            }
        }

        if (mostRecentBingoWins == null || mostRecentBingoWins.Count() != 1) { throw new Exception("Should have exactly 1 board win in the last round"); }
        var lastWin = mostRecentBingoWins.ElementAt(0);

        return lastWin.WinningBoard.CalculateScore(lastWin.MostRecentCallout);
    }

    private IEnumerable<BingoWin> PlayBingo(IEnumerable<BingoBoard> boards, int numberCallout)
    {
        var wins = new List<BingoWin>();

        foreach (var board in boards)
        {
            board.MarkNumber(numberCallout);
            if (board.HasBingo)
            {
                var win = new BingoWin { WinningBoard = board, MostRecentCallout = numberCallout };
                wins.Add(win);
            }
        }

        return wins;
    }
}