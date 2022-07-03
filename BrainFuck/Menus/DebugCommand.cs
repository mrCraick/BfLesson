using BrainFuck.Interfaces.Menus;
using BrainFuck.IO;

namespace BrainFuck.Menus;

public sealed class DebugCommand : ICommand
{
    private readonly string _bfProgram;
    private readonly string _dataOperations;

    public DebugCommand(string bfProgram)
    {
        _bfProgram = bfProgram;
    }

    public void Execute()
    {
        Console.Clear();
        var bfCodeDebugOutput = new BfCodeDebugOutput(_bfProgram);
        bfCodeDebugOutput.Print();
        while (true)
        {
            var keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.N)
            {
                var canMoveNext = bfCodeDebugOutput.PrintNextStep();
                
                if (canMoveNext == false)
                {
                    return;
                }
            }
            else if (keyInfo.Key == ConsoleKey.E)
            {
                return;
            }
            else if (keyInfo.Key == ConsoleKey.R)
            {
                bfCodeDebugOutput.MoveCursorToSpecificPoint();
            }
        };
    }
}