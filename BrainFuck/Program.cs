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
                new DebugCommand("123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789123456789")));
        return menuBuilder.Build();
    }
}

 //.AddNewMenuLine(
 //               new MenuLine(
 //                   "Прыгнуть на нужную точку кода",
 //                   new CursorTeleport("123456789123456789123456789123ААААААААААААААААААААААААААААDDDDDDDDDDDDDDDDFDDDDDDDDDDDDDDDDDDDDDDАААААААААААААHHHHHHHHHHHHHHHHHHHHHHHWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWf")))

//public class CursorTeleport : ICommand
//{

//    private readonly string _bfProgram;
//    public int codePoint { get; set; }

//    public BfCodeDebugOutput bfCodeDebugOutput;

//    private readonly IBfInterpretation _bfInterpretation;
//    public CursorTeleport(IBfInterpretation bfInterpretation)
//    {
//        _bfInterpretation = bfInterpretation;

//    }

//    public CursorTeleport(string bfProgram)
//    {
//        _bfProgram = bfProgram;
//        bfCodeDebugOutput = new BfCodeDebugOutput(_bfProgram); 
//    }

//    public void Execute()
//    {
//        Console.Clear();
//        Console.WriteLine("Введите точку кода, куда хотите переместиться: ");
//        codePoint = Convert.ToInt32(Console.ReadLine());
//        MoveToBFCode(codePoint);
//        Console.ReadKey();
//    }

//    public void MoveToBFCode(int codePoint)
//    {

//        if (codePoint <= Console.WindowWidth / 2 && codePoint > 0)
//        {
//            MoveToStartBFCode(codePoint);
//        }

//        else if (codePoint > Console.WindowWidth / 2
//            && codePoint < _bfProgram.Length - Console.WindowWidth / 2) //мы узнали, что точка находится во второй зоне
//        {

//            MoveToTheMiddleBFCode(codePoint);
//        }
//        else if (codePoint >= _bfProgram.Length - Console.WindowWidth / 2)
//        {

//            MoveToEndBFCode(codePoint);
//        }
//        else
//        {
//            Console.WriteLine("Запрашиваемая точка вне предела кода.");

//        }
//    }




//    public void MoveToStartBFCode(int codePoint)
//    {
//        Console.Clear();
//        bfCodeDebugOutput._index = 0;
//        _offset = codePoint;
//        for (int i = 0; i < Console.WindowWidth; i++)
//        {
//            Console.Write(_bfProgram[i]);
//            _index++;
//        }
//        PrintCoursor(codePoint);
       
//    }

//    public void MoveToTheMiddleBFCode(int codePoint)
//    {
//        Console.Clear();
//        _index = 0;
//        _offset = codePoint;
//        for (int i = codePoint - Console.WindowWidth / 2; i < codePoint + Console.WindowWidth / 2; i++)
//        {
//            Console.Write(_bfProgram[i]);
//            _index++;
//        }
//        PrintCoursor(Console.WindowWidth / 2);
        

//    }

//    public void MoveToEndBFCode(int codePoint)
//    {
//        Console.Clear();
//        _index = 0;
//        _offset = codePoint;
//        for (int i = _bfProgram.Length - Console.WindowWidth; i < _bfProgram.Length; i++)
//        {
//            Console.Write(_bfProgram[i]);
//            _index++;
//        }
//        PrintCoursor(Console.WindowWidth - (_bfProgram.Length - codePoint));
//    }

//    public void PrintCoursor(int codePoint)
//    {
//        for (int i = 0; i < codePoint; i++)
//        {
//            Console.Write(' ');
//        }
//        Console.Write('^');
//    }


//}