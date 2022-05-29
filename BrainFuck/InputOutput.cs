namespace BrainFuck;

public class InputOutput
{
    private readonly TextReader _reader;
    private readonly TextWriter _writer;

    public InputOutput(TextReader output, TextWriter input)
    {
        _reader = output;
        _writer = input;
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
}