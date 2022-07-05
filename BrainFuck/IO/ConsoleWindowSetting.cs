using BrainFuck.Interfaces.IO;

namespace BrainFuck.IO;

public class ConsoleWindowSetting : IWindowSetting
{
    public int WindowWidth => Console.WindowWidth;
}