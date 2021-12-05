using AdventOfCode.Models;

namespace AdventOfCode.Challenges;

public class AdventChallenge3a : IAdventChallenge
{
    public string ChallengeNumber => "3a";

    public object PerformChallenge()
    {
        var challengeData = @"ChallengeData/Challenge3Data.txt";
        var binaryTrackers = new List<BinaryTracker>();

        foreach (string line in File.ReadLines(challengeData))
        {
            while (binaryTrackers.Count < line.Length)
            {
                binaryTrackers.Add(new BinaryTracker());
            }

            for(int i = 0; i < line.Length; i++)
            {
                if (line[i] == '0') { binaryTrackers[i].ZeroCount++; }
                else if (line[i] == '1') { binaryTrackers[i].OneCount++; }
                else { throw new Exception("All values must be either 0 or 1"); }
            }
        }

        string mostCommonBinaryNumberString = "";
        string leastCommonBinaryNumberString = "";
        foreach (var tracker in binaryTrackers)
        {
            if (tracker.ZeroCount > tracker.OneCount)
            {
                mostCommonBinaryNumberString += '0';
                leastCommonBinaryNumberString += '1';
            }
            else if (tracker.OneCount > tracker.ZeroCount)
            {
                mostCommonBinaryNumberString += '1';
                leastCommonBinaryNumberString += '0';
            }
            else { throw new Exception("Zero and one count should never be equal"); }
        }

        int gammaRate = Convert.ToInt32(mostCommonBinaryNumberString, 2);
        int epsilonRate = Convert.ToInt32(leastCommonBinaryNumberString, 2);

        return gammaRate * epsilonRate;
    }
}