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
}