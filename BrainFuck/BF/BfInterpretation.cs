using BrainFuck.Interfaces.BF;
using BrainFuck.Interfaces.IO;

namespace BrainFuck.BF;

public class BfInterpretation : IBfInterpretation
{
    private readonly IInputOutput _inputOutput;

    public BfInterpretation(IInputOutput inputOutput)
    {
        _inputOutput = inputOutput;
    }

    public void Run()
    {
        Run("++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.");
    }

    public void Run(string program)
    {
        var brainFuckCode = new Repository(program);
        var brainFuckFunction = new BrainFuckFunction(brainFuckCode, _inputOutput);
        var dataOperations = new DataOperations(brainFuckFunction);

        dataOperations.EnumСodeBrainFuck(brainFuckCode.Program);

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey(true);
    }
}