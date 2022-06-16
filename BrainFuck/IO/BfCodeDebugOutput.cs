namespace BrainFuck.IO;

public sealed class BfCodeDebugOutput
{
    private readonly string _bfProgram;
    private readonly char _carriageSymbol;

    private int _index;
    private int _offset;

    private int GetBfProgramLength => _bfProgram.Length;
    private bool ProgramMoreConsoleLineSize => Console.WindowWidth < GetBfProgramLength;
    private bool CanMoveToNextStep => _index + _offset < GetBfProgramLength - 1;
    private bool CanMoveCarriageWithBigProgram => ProgramMoreConsoleLineSize && 
                                                  CanMoveToNextStep && 
                                                  (Console.WindowWidth / 2 > _index || _offset == GetBfProgramLength - Console.WindowWidth);

    private bool CanMoveCarriage => CanMoveCarriageWithBigProgram || CanMoveToNextStep && ProgramMoreConsoleLineSize == false;
    private bool CanMoveCode => ProgramMoreConsoleLineSize && CanMoveToNextStep;


    public BfCodeDebugOutput(string bfProgram) : this(bfProgram, '^')
    {
    }

    public BfCodeDebugOutput(string bfProgram, char carriageSymbol)
    {
        _index = 0;
        _offset = -1;
        _bfProgram = bfProgram;
        _carriageSymbol = carriageSymbol;
    }

    public void Print()
    {
        Print(0);
    }

    public void Print(int startIndex)
    {
        PrintCode();

        for (var i = 0; i < startIndex; i++)
        {
            Console.Write(' ');
        }

        Console.Write(_carriageSymbol);
        _index = startIndex;
    }

    public bool PrintNextStep()
    {

        if (CanMoveCarriage)
        {
            MoveCarriageSymbol();
            return true;
        }

        if(CanMoveCode)
        {
            PrintCode();
            return true;
        }

        return false;
    }

    private void PrintCode()
    {
        Console.SetCursorPosition(0 , 0);
        _offset += 1;

        for (int i = _offset; i < Console.WindowWidth + _offset && i < GetBfProgramLength - 1; i++)
        {
            Console.Write(_bfProgram[i]);
        }

        Console.Write("\n");
        Console.SetCursorPosition(_index, 1);
    }

    private void MoveCarriageSymbol()
    {
        Console.Write($"\b {_carriageSymbol}");
        _index += 1;
    }

    public void MoveCursorToSpecificPoint()
    {
        int halfOfConsoleWindow = Console.WindowWidth / 2;
        Console.Clear();
        Console.WriteLine("Введите индекс для перехода:");
        int codePointer = Convert.ToInt32(Console.ReadLine());

        if (codePointer >= 0 && codePointer <= halfOfConsoleWindow)
        {
            MoveCursorToFirstPartOfCode(codePointer);
        }

        else if (codePointer > halfOfConsoleWindow && codePointer < _bfProgram.Length - halfOfConsoleWindow)
        {
            MoveCursorToMiddlePartOfCode(codePointer);
        }

        else if (codePointer >= _bfProgram.Length - halfOfConsoleWindow && codePointer <= _bfProgram.Length - 1)
        {
            MoveCursonToLastPartOfCode(codePointer);
        }

        else
        {
            Console.WriteLine("Вне диапазона!");
            Console.ReadLine();
            MoveCursorToSpecificPoint();
        }
    }

    public void MoveCursorToFirstPartOfCode(int codePointer)
    {
        Console.Clear();
        _offset = 0;
        PrintSpecificCode(0);
        PrintCarriageSymbol(codePointer);
    }

    public void MoveCursorToMiddlePartOfCode(int codePointer)
    {
        Console.Clear();
        _offset = codePointer - Console.WindowWidth / 2;
        PrintSpecificCode(codePointer - Console.WindowWidth / 2);
        PrintCarriageSymbol(Console.WindowWidth / 2);
    }
    
    public void MoveCursonToLastPartOfCode(int codePointer)
    {
        Console.Clear();
        _offset = _bfProgram.Length - Console.WindowWidth;
        PrintSpecificCode((_bfProgram.Length) - Console.WindowWidth);
        PrintCarriageSymbol(Console.WindowWidth - (_bfProgram.Length - codePointer));
    }
   
    public void PrintCarriageSymbol(int codePointer)
    {
        Console.SetCursorPosition(0, 1);
        for (int i = 0; i < codePointer; i++)
        {
            Console.Write(' ');
        }
        _index = codePointer;
        Console.Write(_carriageSymbol);
    }

    public void PrintSpecificCode(int index)
    {
        Console.SetCursorPosition(0, 0);
        for (int i = index; i < Console.WindowWidth + index; i++)
        {
            Console.Write(_bfProgram[i]);
        }
    }
}