using BrainFuck.Interfaces.Menus;

namespace BrainFuck.Menus;

public class ConsoleCursorWrapper : ICursorWrapper
{
    public void SetCursorPosition(int left, int top)
    {
        Console.SetCursorPosition(left, top);
    }
}