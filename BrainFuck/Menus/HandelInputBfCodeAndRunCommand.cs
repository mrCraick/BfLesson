using System.Text;
using BrainFuck.BF;
using BrainFuck.Interfaces.BF;
using BrainFuck.Interfaces.Menus;

namespace BrainFuck.Menus;

public class HandelInputBfCodeAndRunCommand : ICommand
{
    private const string BF_SYMBOLS = "+-<>.,[]";

    private readonly StringBuilder _stringBuilder;
    private readonly IBfInterpretation _bfInterpretation;

    public HandelInputBfCodeAndRunCommand(IBfInterpretation bfInterpretation)
    {
        _bfInterpretation = bfInterpretation;
        _stringBuilder = new StringBuilder();
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("Enter the program:");

        while (true)
        {
            var consoleKeyInfo = Console.ReadKey(true);

            var keyChar = consoleKeyInfo.KeyChar;

            if (BF_SYMBOLS.Contains(keyChar))
            {
                _stringBuilder.Append(keyChar);

                Console.Write(keyChar);
            }
            else if (consoleKeyInfo.Key == ConsoleKey.Enter)
            {
                var program = _stringBuilder.ToString();
                if (CheckCode(program))
                {
                    _bfInterpretation.Run(program);
                    break;
                }

                Console.WriteLine("\nBloody bastard!");
                _stringBuilder.Clear();
            }
            else if(consoleKeyInfo.Key == ConsoleKey.Backspace)
            {
                if (_stringBuilder.Length != 0)
                {
                    _stringBuilder.Remove(_stringBuilder.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
        }
    }

    private bool CheckCode(string program)
    {
        var balance = 0;

        foreach (var item in program)
        {
            if (item == '[')
            {
                balance += 1;
            }
            else if(item == ']' && balance <= 0)
            {
                return false;
            }
            else if(item == ']')
            {
                balance -= 1;
            }
        }

        return balance == 0;
    }
}