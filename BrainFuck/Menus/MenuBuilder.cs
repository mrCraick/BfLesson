using BrainFuck.Interfaces.Menus;

namespace BrainFuck.Menus;

internal sealed class MenuBuilder : IMenuBuilder
{
    private readonly List<IMenuLine> _menuLines;
    private readonly IMenuTextWriter _menuTextWriter;

    public ExitToken ExitToken { get; }

    public MenuBuilder(IMenuTextWriter menuTextWriter)
    {
        _menuTextWriter = menuTextWriter;
        _menuLines = new List<IMenuLine>();

        ExitToken = new ExitToken();
    }
    public IMenuBuilder AddNewMenuLine(IMenuLine newMenuLine)
    {
        _menuLines.Add(newMenuLine);

        return this;
    }

    public IMenu Build()
    {
        return new Menu(_menuTextWriter, _menuLines, ExitToken);
    }
}