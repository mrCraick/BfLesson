using BrainFuck.Menus;

namespace BrainFuck.Interfaces.Menus;

public interface IMenuTextWriter
{
    void PrintMenu(IEnumerable<IMenuLine> menuLines, int selectedMenuIndex);
}