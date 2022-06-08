using BrainFuck.BF;
using BrainFuck.Interfaces.Menus;
using BrainFuck.IO;
using BrainFuck.Menus;

namespace BrainFuck;

public static class Program
{
    public static void Main()
    {
        var menu = BuildMenu();

        menu.RunMenu();
    }

    private static IMenu BuildMenu()
    {
        var consoleCursorWrapper = new ConsoleCursorWrapper();
        var inputOutput = new InputOutput(Console.In, Console.Out, consoleCursorWrapper);
        var menuBuilder = new MenuBuilder(inputOutput);
        var bfInterpretation = new BfInterpretation(inputOutput);
        menuBuilder
            .AddNewMenuLine(
                new MenuLine("Запустить стандартную программу", 
                new DefaultBrainFuckCommand(bfInterpretation)))
            .AddNewMenuLine(
                new MenuLine("Ввести программу вручную", 
                new HandelInputBfCodeAndRunCommand(bfInterpretation)))
            .AddNewMenuLine(
                new MenuLine("Выйти", 
                new ExitCommand(menuBuilder.ExitToken)));

        return menuBuilder.Build();
    }
}