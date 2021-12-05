using AdventOfCode.Models;

namespace AdventOfCode.Challenges;

public class AdventChallenge3b : IAdventChallenge
{
    public string ChallengeNumber => "3b";

    public object PerformChallenge()
    {
        var challengeData = @"ChallengeData/Challenge3Data.txt";
        var allLines = File.ReadAllLines(challengeData);

        string oxygenRatingBinaryString = ProcessValues(allLines, true);
        string co2ScrubberRatingBinaryString = ProcessValues(allLines, false);

        int oxygenRating = Convert.ToInt32(oxygenRatingBinaryString, 2);
        int co2ScrubberRating = Convert.ToInt32(co2ScrubberRatingBinaryString, 2);

        return oxygenRating * co2ScrubberRating;
    }

    private string ProcessValues(string[] values, bool useHighestCountAndOneWhenTied)
    {
        return ProcessValues(values, useHighestCountAndOneWhenTied, 0);
    }

    private string ProcessValues(string[] values, bool useHighestCountAndOneWhenTied, int indexToLookAt)
    {
        if (values.Length == 1) {
            return values[0]; }

        var zeroValues = new List<string>();
        var oneValues = new List<string>();

        foreach (string value in values)
        {
            if (value[indexToLookAt] == '0') { zeroValues.Add(value); }
            else if (value[indexToLookAt] == '1') { oneValues.Add(value); }
            else { throw new Exception("All values must be either 0 or 1"); }
        }

        bool useZeroValues;
        if (zeroValues.Count > oneValues.Count) { useZeroValues = true; }
        else if (oneValues.Count > zeroValues.Count) { useZeroValues = false; }
        else { useZeroValues = false; }

        if (!useHighestCountAndOneWhenTied) { useZeroValues = !useZeroValues; }

        if (useZeroValues) { return ProcessValues(zeroValues.ToArray(), useHighestCountAndOneWhenTied, ++indexToLookAt); }
        else { return ProcessValues(oneValues.ToArray(), useHighestCountAndOneWhenTied, ++indexToLookAt); }

        throw new ArgumentException("Value array is empty");
    }
}