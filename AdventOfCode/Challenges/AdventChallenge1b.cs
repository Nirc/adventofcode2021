using AdventOfCode.Models;

namespace AdventOfCode.Challenges;

public class AdventChallenge1b : IAdventChallenge
{
    public string ChallengeNumber => "1b";

    public object PerformChallenge()
    {
        var challengeData = @"ChallengeData/Challenge1Data.txt";
        var incompleteDepthDatas = new List<DepthData>();
        var completeDepthDatas = new List<DepthData>();
        int currentDepthId = 1;

        foreach (string line in File.ReadLines(challengeData))
        {
            incompleteDepthDatas.Add(new DepthData(currentDepthId));

            foreach(var incompleteDepthData in incompleteDepthDatas.ToList())
            {
                incompleteDepthData.AddDepthValue(int.Parse(line));
                if (incompleteDepthData.IsFull)
                {
                    incompleteDepthDatas.Remove(incompleteDepthData);
                    completeDepthDatas.Add(incompleteDepthData);
                }
            }

            currentDepthId++;
        }

        int increasedSumCount = 0;
        int? previousSum = null;
        foreach(var depthData in completeDepthDatas)
        {
            if (previousSum != null && depthData.GetDepthValues().Sum() > previousSum)
            {
                increasedSumCount++;
            }

            previousSum = depthData.GetDepthValues().Sum();
        }

        return increasedSumCount++;
    }
}