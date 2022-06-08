using BrainFuck.Interfaces.Menus;

namespace BrainFuck.Menus;

public class Menu : IMenu
{
    private readonly IMenuTextWriter _menuTextWriter;
    private readonly ExitToken _exitToken;
    private readonly IReadOnlyList<IMenuLine> _menuLines;

    public Menu(IMenuTextWriter menuTextWriter, IEnumerable<IMenuLine> menuLines, ExitToken exitToken)
    {
        _menuTextWriter = menuTextWriter;
        _exitToken = exitToken;
        _menuLines = new List<IMenuLine>(menuLines);
    }

    public void RunMenu()
    {

        var menuIndex = 0;

        _menuTextWriter.PrintMenu(_menuLines, menuIndex);

        while (true)
        {
            var consoleKeyInfo = Console.ReadKey(true);

            if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
            {
                menuIndex -= 1;
                menuIndex = menuIndex < 0 ? 0 : menuIndex;
            }
            else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
            {
                menuIndex += 1;
                menuIndex = menuIndex >= _menuLines.Count ? _menuLines.Count - 1 : menuIndex;
            }
            else if (consoleKeyInfo.Key == ConsoleKey.Enter)
            {
                var item = _menuLines[menuIndex];
                item.Execute();
                if (_exitToken.IsCanceled == false)
                {
                    Console.Clear();
                }
            }

            if (_exitToken.IsCanceled)
            {
                return;
            }

            _menuTextWriter.PrintMenu(_menuLines, menuIndex);
        }
    }
}