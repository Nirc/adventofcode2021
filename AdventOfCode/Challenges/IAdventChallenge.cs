namespace AdventOfCode.Challenges;
public interface IAdventChallenge
{
    public string ChallengeNumber { get; }
    public object PerformChallenge();
}