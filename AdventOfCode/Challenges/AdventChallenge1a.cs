namespace AdventOfCode.Challenges;

public class AdventChallenge1a : IAdventChallenge
{
    public string ChallengeNumber => "1a";

    public object PerformChallenge()
    {
        int increasedDepthCount = 0;
        var challengeData = @"ChallengeData/Challenge1Data.txt";

        int? previousDepth = null;
        foreach (string line in File.ReadLines(challengeData))
        {
            int currentDepth = int.Parse(line);
            if (previousDepth != null && currentDepth > previousDepth)
            {
                increasedDepthCount++;
            }
            previousDepth = currentDepth;
        }

        return increasedDepthCount;
    }
}