using BrainFuck.Interfaces.IO;
using BrainFuck.Interfaces.Menus;
using BrainFuck.Menus;

namespace BrainFuck.IO;

public class InputOutput : IInputOutput, IMenuTextWriter
{
    private readonly TextReader _reader;
    private readonly TextWriter _writer;
    private readonly ICursorWrapper _cursorWrapper;

    public InputOutput(ICursorWrapper cursorWrapper) : this(Console.In, Console.Out, cursorWrapper)
    {

    }

    public InputOutput(TextReader output, TextWriter input, ICursorWrapper cursorWrapper)
    {
        _reader = output;
        _writer = input;
        _cursorWrapper = cursorWrapper;
    }

    public char GetCharUser()
    {
        while (true)
        {
            var userInput = GetStringUser();
            if (char.TryParse(userInput, out var result))
            {
                return result;
            }
        }
    }
    public string GetStringUser()
    {
        return _reader.ReadLine() ?? string.Empty;
    }
    public void OutputConsole(string messageOrChar)
    {
        _writer.Write(messageOrChar);
    }

    public void PrintMenu(IEnumerable<IMenuLine> menuLines, int selectedMenuIndex)
    {
        _cursorWrapper.SetCursorPosition(0, 0);
        var index = 0;
        foreach (var menuLine in menuLines)
        {
            if (index == selectedMenuIndex)
            {
                _writer.Write(">");
            }
            else
            {
                _writer.Write(" ");
            }

            _writer.Write($"{index + 1}. {menuLine.Name}");
            _writer.Write("\n");
            index += 1;
        }
    }
}