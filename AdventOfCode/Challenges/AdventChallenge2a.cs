using AdventOfCode.Models;

namespace AdventOfCode.Challenges;

public class AdventChallenge2a : IAdventChallenge
{
    public string ChallengeNumber => "2a";

    public object PerformChallenge()
    {
        var challengeData = @"ChallengeData/Challenge2Data.txt";
        var commandCalculator = new SubmarineCommandCalculator2a();

        foreach (string line in File.ReadLines(challengeData))
        {
            var lineValues = line.Split(' ');
            var command = Enum.Parse<SubmarineCommand>(lineValues[0], true);
            var commandValue = int.Parse(lineValues[1]);

            commandCalculator.ExecuteCommand(command, commandValue);
        }

        return commandCalculator.CurrentValue;
    }
}