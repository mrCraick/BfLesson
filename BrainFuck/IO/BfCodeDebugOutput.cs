using BrainFuck.Interfaces.IO;
using System.Text;

namespace BrainFuck.IO;

public sealed class BfCodeDebugOutput
{
    private readonly IWindowSetting _windowSetting;

    private readonly StringBuilder _codeStringBuilder;
    private readonly StringBuilder _carriageStringBuilder;

    private readonly string _bfProgram;
    private readonly char _carriageSymbol;

    private int _index;
    private int _offset;

    private int GetBfProgramLength => _bfProgram.Length;
    private bool ProgramMoreConsoleLineSize => _windowSetting.WindowWidth < GetBfProgramLength;
    private bool CanMoveToNextStep => _index + _offset < GetBfProgramLength - 1;
    private bool CanMoveCarriageWithBigProgram => ProgramMoreConsoleLineSize &&
                                                  CanMoveToNextStep &&
                                                  (HalfWindowWidth > _index ||
                                                   _offset == GetBfProgramLength - _windowSetting.WindowWidth);

    private bool CanMoveCarriage =>
        CanMoveCarriageWithBigProgram || CanMoveToNextStep && ProgramMoreConsoleLineSize == false;

    private bool CanMoveCode => ProgramMoreConsoleLineSize && CanMoveToNextStep;

    private int HalfWindowWidth => _windowSetting.WindowWidth / 2;

    public BfCodeDebugOutput(string bfProgram, IWindowSetting windowSetting) : this(bfProgram, '^', windowSetting)
    {
    }

    public BfCodeDebugOutput(string bfProgram, char carriageSymbol, IWindowSetting windowSetting)
    {
        _index = 0;
        _offset = -1;
        _bfProgram = bfProgram;
        _carriageSymbol = carriageSymbol;
        _windowSetting = windowSetting;
        _codeStringBuilder = new StringBuilder();
        _carriageStringBuilder = new StringBuilder();
    }

    public bool PrintNextStep()
    {
        if (CanMoveCarriage)
        {
            MoveCarriageSymbol();
            return true;
        }

        if (CanMoveCode)
        {
            MoveCode();
            return true;
        }

        return false;
    }

    public void MoveToBfCode()
    {
        MoveToBfCode(0);
    }

    public void MoveToBfCode(int codePoint)
    {
        if (codePoint <= HalfWindowWidth && codePoint >= 0)
        {
            MoveToStartBFCode(codePoint);
        }
        else if (codePoint > HalfWindowWidth
                 && codePoint < _bfProgram.Length - HalfWindowWidth)
        {
            MoveToTheMiddleBFCode(codePoint);
        }
        else if (codePoint >= _bfProgram.Length - HalfWindowWidth)
        {
            MoveToEndBFCode(codePoint);
        }
        else
        {
            throw new IndexOutOfRangeException("Точка находится вне программы");
        }
    }

    public string GetContent()
    {
        var contentStringBuilder = new StringBuilder();

        contentStringBuilder.AppendLine(_codeStringBuilder.ToString());
        contentStringBuilder.AppendLine(_carriageStringBuilder.ToString());

        return contentStringBuilder.ToString();
    }

    private void MoveCode()
    {
        var newOffset = _offset + 1;
        var newIndex = _index;

        UpdateContent(newOffset, newIndex);
    }

    private void MoveCarriageSymbol()
    {
        var newOffset = _offset;
        var newIndex = _index + 1;

        UpdateContent(newOffset, newIndex);
    }

    private void MoveToStartBFCode(int codePoint)
    {
        var newOffset = 0;
        var newIndex = codePoint;

        UpdateContent(newOffset, newIndex);
    }

    private void MoveToTheMiddleBFCode(int codePoint)
    {
        var newOffset = codePoint - HalfWindowWidth;
        var newIndex = HalfWindowWidth;

        UpdateContent(newOffset, newIndex);
    }

    private void MoveToEndBFCode(int codePoint)
    {
        var newOffset = _bfProgram.Length - _windowSetting.WindowWidth;
        var newIndex = _windowSetting.WindowWidth - (_bfProgram.Length - codePoint);

        UpdateContent(newOffset, newIndex);
    }

    private void UpdateContent(int newOffset, int newIndex)
    {
        _offset = newOffset;
        _index = newIndex;

        UpdateCodeStringBuilder();
        UpdateCarriageStringBuilder();
    }

    private void UpdateCodeStringBuilder()
    {
        _codeStringBuilder.Clear();

        for (var i = _offset; i < GetBfProgramLength && i < _windowSetting.WindowWidth + _offset; i++)
        {
            _codeStringBuilder.Append(_bfProgram[i]);
        }
    }

    private void UpdateCarriageStringBuilder()
    {
        _carriageStringBuilder.Clear();

        for (var i = 0; i < _index; i++)
        {
            _carriageStringBuilder.Append(' ');
        }

        _carriageStringBuilder.Append(_carriageSymbol);
    }
}