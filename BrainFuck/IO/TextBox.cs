using BrainFuck.Interfaces.IO;

namespace BrainFuck.IO;

public class TextRender
{
    private readonly IReadOnlyList<IContentProvider> _contentProviders;

    public TextRender(IEnumerable<IContentProvider> contentProviders)
    {
        _contentProviders = new List<IContentProvider>(contentProviders).AsReadOnly();
    }

    public void RenderAll()
    {
        Console.SetCursorPosition(0, 0);
        Console.Clear();

        for (var i = 0; i < _contentProviders.Count; i++)
        {
            RenderCell(i);
        }
    }

    public void RenderCell(int i)
    {
        Console.Write(_contentProviders[i].GetContent());
    }
}