namespace BrainFuck;

public static class Program
{
    public static void Main()
    {
        var exitToken = new ExitToken();

        var menuLines = new[]
        {
            new MenuLine("1. Запустить стандартную программу", new DefaultBrainFuckCommand()), 
            new MenuLine("2. Выйти", new ExitCommand(exitToken))
        };

        var menuIndex = 0;
        PrintMenu(menuLines, menuIndex);
        while (true)
        {
            var consoleKeyInfo = Console.ReadKey(true);

            if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
            {
                menuIndex -= 1;
                menuIndex = menuIndex < 0 ? 0 : menuIndex;
            }
            else if(consoleKeyInfo.Key == ConsoleKey.DownArrow)
            {
                menuIndex += 1;
                menuIndex = menuIndex >= menuLines.Length ? menuLines.Length - 1 : menuIndex;
            }
            else if(consoleKeyInfo.Key == ConsoleKey.Enter)
            {
                var item = menuLines[menuIndex];
                item.Execute();
                if (exitToken.IsCanceled == false)
                {
                   Console.Clear();
                }
            }

            if (exitToken.IsCanceled)
            {
                return;
            }
            
            PrintMenu(menuLines, menuIndex);
        }
    }

    private static void PrintMenu(MenuLine[] menuLines, int menuIndex)
    {
        Console.SetCursorPosition(0, 0);
        var index = 0;
        foreach (var menuLine in menuLines)
        {
            if (index == menuIndex)
            {
                Console.Write(">");
            }
            else
            {
                Console.Write(" ");
            }

            Console.Write(menuLine.Name);
            Console.Write("\n");
            index += 1;
        }
    }
}