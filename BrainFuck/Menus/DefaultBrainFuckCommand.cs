using BrainFuck.Interfaces.Menus;

namespace BrainFuck.Menus;

public class DefaultBrainFuckCommand : ICommand
{
    private readonly IBfInterpretation _bfInterpretation;

    public DefaultBrainFuckCommand(IBfInterpretation bfInterpretation)
    {
        _bfInterpretation = bfInterpretation;
    }

    public void Execute()
    {
        Console.Clear();

        _bfInterpretation.Run();
    }
}