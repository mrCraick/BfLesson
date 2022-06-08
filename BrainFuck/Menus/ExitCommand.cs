using BrainFuck.Interfaces.Menus;

namespace BrainFuck.Menus;

public class ExitCommand : ICommand
{
    private readonly ExitToken _exitToken;

    public ExitCommand(ExitToken exitToken)
    {
        _exitToken = exitToken;
    }

    public void Execute()
    {
        _exitToken.MakeCanceled();
    }
}