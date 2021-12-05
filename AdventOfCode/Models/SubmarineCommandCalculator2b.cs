namespace AdventOfCode.Models;

public class SubmarineCommandCalculator2b
{
    private int _currentHorizontal = 0;
    private int _currentDepth = 0;
    private int _currentAim = 0;

    public int CurrentValue => _currentHorizontal * _currentDepth;

    public void ExecuteCommand(SubmarineCommand command, int value)
    {
        switch (command)
        {
            case SubmarineCommand.Forward:
                _currentHorizontal += value;
                _currentDepth += _currentAim * value;
                break;
            case SubmarineCommand.Up:
                _currentAim -= value;
                break;
            case SubmarineCommand.Down:
                _currentAim += value;
                break;
            default:
                throw new ArgumentException("Unrecognized submarine command");
        }
    }
}