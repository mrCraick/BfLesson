using BrainFuck.Interfaces.BF;
using BrainFuck.Interfaces.IO;

namespace BrainFuck.BF;

public class BfInterpretation : IBfInterpretation
{
    private readonly IInputOutput _inputOutput;
    private bool _debugMode;

    public bool DebugMode
    {
        get => _debugMode;
        set => _debugMode = false;
    }

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
        var debugMode = new DebugModeSwitch(true);
        var brainFuckCode = new Repository(program);
        var brainFuckFunction = new BrainFuckFunction(brainFuckCode, _inputOutput);
        var dataOperations = new DataOperations(brainFuckFunction, debugMode);

        dataOperations.EnumСodeBrainFuck(brainFuckCode.Program);

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey(true);
    }

    public void SetDebugMode()
    {

    }


}