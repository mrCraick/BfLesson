using BrainFuck.BF;
using BrainFuck.Interfaces.Menus;
using BrainFuck.IO;
using BrainFuck.Menus;
namespace BrainFuck;




/* +++-+++---[-]
 * +++-+++---
 *     ^
 * ++-+++---[
 *     ^
 * -+++---[-]
 *      ^
 * I: 17
 * 17: 1
 * 0: 6
 */
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
        var inputOutput = new InputOutput(consoleCursorWrapper);
        var menuBuilder = new MenuBuilder(inputOutput);
        var bfInterpretation = new BfInterpretation(inputOutput);
        var dataFromRepository = new Repository("++++++++++[>+>+++>+++++++>++++++++++<<<<-]>>>>----------.+++++++.<+++++++++++++.>+++++++.---.++++++.++++++++++.");
        var brainFuckFunction = new BrainFuckFunction(dataFromRepository, inputOutput);
        var dataOperations = new DataOperations(brainFuckFunction);
        menuBuilder
            .AddNewMenuLine(
                new MenuLine(
                    "Запустить стандартную программу",
                    new DefaultBrainFuckCommand(bfInterpretation)))
            .AddNewMenuLine(
                new MenuLine(
                    "Ввести программу вручную",
                    new HandelInputBfCodeAndRunCommand(bfInterpretation)))
            .AddNewMenuLine(
                new MenuLine(
                    "Выйти",
                    new ExitCommand(menuBuilder.ExitToken))
            )
            .AddNewMenuLine(
            new MenuLine(
                "мне не понравилось предыдущее название, вот так гораздо лучше",
                new DebugCommand(dataFromRepository, dataOperations)));
        return menuBuilder.Build();
    }
}