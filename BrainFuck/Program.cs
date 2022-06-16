using System.Text;
using BrainFuck.BF;
using BrainFuck.Interfaces.Menus;
using BrainFuck.IO;
using BrainFuck.Menus;

//Leshey's_Branch

namespace BrainFuck
{
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
                        new ExitCommand(menuBuilder.ExitToken)))
                .AddNewMenuLine(
                    new MenuLine(
                        "Бег по строке для дебага",
                        new DebugCommand("++++++++10--------20++++++++30--------40++++++++50--------60++++++++70--------80++++++++90-------100+++++++110-------120+++++++130-------140+++++++150-------160+++++++170-------180+++++++190-------200")));
            return menuBuilder.Build();
        }
    }
}


