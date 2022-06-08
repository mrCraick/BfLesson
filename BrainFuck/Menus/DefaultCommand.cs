using BrainFuck.Interfaces.Menus;

namespace BrainFuck.Menus;

public class DefaultCommand : ICommand
{
    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("Not From Brainfuck Hello World!");
    }
}