namespace AdventOfCode.Models;

public class SubmarineCommandCalculator2a
{
    private int _currentHorizontal = 0;
    private int _currentDepth = 0;

    public int CurrentValue => _currentHorizontal * _currentDepth;

    public void ExecuteCommand(SubmarineCommand command, int value)
    {
        switch(command)
        {
            case SubmarineCommand.Forward:
                _currentHorizontal += value;
                break;
            case SubmarineCommand.Up:
                _currentDepth -= value;
                break;
            case SubmarineCommand.Down:
                _currentDepth += value;
                break;
            default:
                throw new ArgumentException("Unrecognized submarine command");
        }
    }
}