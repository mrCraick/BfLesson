namespace BrainFuck;

public class DefaultBrainFuckCommand : ICommand
{
    public void Execute()
    {
        Console.Clear();

        var brainFuckCode = new Repository();
        var inputOutput = new InputOutput(Console.In, Console.Out);
        var brainFuckFunction = new BrainFuckFunction(brainFuckCode, inputOutput);
        var dataOperations = new DataOperations(brainFuckFunction);

        dataOperations.EnumСodeBrainFuck(brainFuckCode.Program);

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey(true);
    }
}