using BrainFuck.Interfaces.Menus;

namespace BrainFuck.Menus;

public sealed class MenuLine : IMenuLine
{
    private readonly ICommand _command;

    public string Name { get; }

    public MenuLine(string name, ICommand command)
    {
        Name = name;
        _command = command;
    }

    public void Execute()
    {
        _command.Execute();
    }
}