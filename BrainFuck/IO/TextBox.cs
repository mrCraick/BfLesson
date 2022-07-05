using System.Collections.ObjectModel;

namespace BrainFuck.IO;

public class TextBox
{
    public string? Content { get; private set; }

    public void SetContent(string value)
    {
        Content = value;
    }
}

public class TextRender
{
    private readonly IReadOnlyList<TextBox> _textBoxes;

    public TextRender(IEnumerable<TextBox> textBoxes)
    {
        _textBoxes = new List<TextBox>(textBoxes).AsReadOnly();
    }

    public void RenderAll()
    {
        Console.SetCursorPosition(0, 0);
        Console.Clear();
        for (var i = 0; i < _textBoxes.Count; i++)
        {
            RenderCell(i);
            Console.Write('\n');
        }
    }

    public void RenderCell(int i)
    {
        Console.Write(_textBoxes[i].Content);
    }
}