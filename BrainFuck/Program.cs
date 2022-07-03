using System.Text;
using BrainFuck;
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
            //var textBlock1 = new TextBlock(0, 1, Console.WindowWidth);
            //var textBlock2 = new TextBlock(1, 1, Console.WindowWidth);
            //var textBlock3 = new TextBlock(2, 1, Console.WindowWidth);


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
                        new DebugCommand("++++++++10--------20++++++++30--------40++++++++50--------60++++++++70--------80++++++++90-------100+++++++110-------120+++++++130-------140+++++++150-------160+++++++170-------180+++++++190-------200")))
                .AddNewMenuLine(
                    new MenuLine(
                        "Тру дебаг в разработке",
                        new DebugCommand("++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.")));

            return menuBuilder.Build();
        }
    }
}

//public class DebugCommand2 : ICommand
//{
//    private IBfInterpretation _iBfInterpretation;
//    private readonly string _bfProgram;

//    public DebugCommand2(string bfProgram)
//    {
//        _bfProgram = bfProgram;
//    }

//    public void Execute()
//    {
//        Console.Clear();
//        var bfCodeDebugOutput = new BfCodeDebugOutput(_bfProgram);
//        bfCodeDebugOutput.Print();
//        while (true)
//        {
//            var keyInfo = Console.ReadKey(true);

//            if (keyInfo.Key == ConsoleKey.N)
//            {
//                var canMoveNext = bfCodeDebugOutput.PrintNextStep();

//                if (canMoveNext == false)
//                {
//                    return;
//                }
//            }
//            else if (keyInfo.Key == ConsoleKey.E)
//            {
//                return;
//            }
//            else if (keyInfo.Key == ConsoleKey.R)
//            {
//                bfCodeDebugOutput.MoveCursorToSpecificPoint();
//            }
//        };
//    }
//}

//public class DebugModeSwitch
//{
//    private bool _enabled;
//    public bool Enablded 
//    {
//        get => _enabled;
//    }

//    public DebugModeSwitch() : this(false)
//    {
//    }

//    public DebugModeSwitch(bool enabled) 
//    {
//        _enabled = enabled;
//    }

//    public void Enable()
//    {
//        _enabled = true;
//    }

//    public void Disable()
//    {
//        _enabled = false;
//    }
//}

//public class TextBlock
//{
//    private readonly int _lineCountSymbols;
    
//    public string Content { get; private set; }
//    public int Order { get; }
//    public int CountOfLines { get; }

//    private int MaxContentLenght => CountOfLines * _lineCountSymbols;

//    public TextBlock(int order, int sizeLine, int lineCountSymbols)
//    {
//        Order = order;
//        CountOfLines = sizeLine;
//        _lineCountSymbols = lineCountSymbols;
//    }

//    public void SetContent(string value)
//    {
//        if (value.Length > MaxContentLenght)
//        {
//            throw new ArgumentException($"Текст слишком большой, ожидается не более {MaxContentLenght}, а пришло {value.Length}");
//        }

//        Content = value;
//    }

//}

//public class TextRender
//{
//    private TextBlock[] _textBlocks;

//    public TextRender(TextBlock[] textBoxes)
//    {
//        _textBlocks = textBoxes;
//    }

//    public void Render()
//    {
//        for (var i = 0; i < _textBlocks.Length; i++)
//        {
//            Console.SetCursorPosition(0, _textBlocks[i].Order);
//            Console.Write(_textBlocks[i].Content);
//        }
//    }


//}

