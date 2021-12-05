using AdventOfCode.Challenges;

var challengesToPerform = new IAdventChallenge[]
{
    new AdventChallenge1a(),
    new AdventChallenge1b(),
    new AdventChallenge2a(),
    new AdventChallenge2b(),
    new AdventChallenge3a(),
    new AdventChallenge3b(),
    new AdventChallenge4a(),
    new AdventChallenge4b(),
};
var challengeResults = new Dictionary<string, object>();

foreach (var challenge in challengesToPerform)
{
    var result = challenge.PerformChallenge();
    challengeResults.Add(challenge.ChallengeNumber, result);
}

foreach(var result in challengeResults)
{
    Console.WriteLine($"Challenge {result.Key} result: {result.Value}");
}

Console.ReadLine();