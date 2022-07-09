using BrainFuck.BF;
using BrainFuck.Interfaces.BF;
using BrainFuck.Interfaces.Menus;
using BrainFuck.IO;

namespace BrainFuck.Menus;

public sealed class DebugCommand : ICommand
{
    private readonly Repository _repository;
    private readonly IDataOperations _dataOperations;

    public DebugCommand(Repository repository, IDataOperations dataOperations)
    {
        _repository = repository;
        _dataOperations = dataOperations;
    }

    public void Execute()
    {
        Console.Clear();
        var program = _repository.Program;
        var bfCodeDebugOutput = new BfCodeDebugOutput(program, new ConsoleWindowSetting());
        var textRender = new TextRender(new[] { bfCodeDebugOutput });

        bfCodeDebugOutput.MoveToBfCode();
        textRender.RenderAll();

        var index = 0;
        while (true)
        {
            var keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.N)
            {
                var oldIndex = index;
                index = _dataOperations.ExecuteOneSymbol(program, index);
                var canMoveNext = true;

                if (oldIndex == index)
                {
                    canMoveNext = bfCodeDebugOutput.PrintNextStep();
                }
                else
                {
                    bfCodeDebugOutput.MoveToBfCode(index);
                }

                if (canMoveNext == false)
                {
                    return;
                }

                textRender.RenderAll();

                index += 1;
            }
            else if (keyInfo.Key == ConsoleKey.E)
            {
                return;
            }
        }
    }
}