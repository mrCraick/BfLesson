using BrainFuck.Interfaces.BF;

namespace BrainFuck.BF;

public class DataOperations : IDataOperations
{
    private readonly IBrainFuckFunction _brainFuckFunction;

    public DataOperations(IBrainFuckFunction brainFuckFunction)
    {
        _brainFuckFunction = brainFuckFunction;
    }

    public void EnumСodeBrainFuck(string brainFuckCode)
    {
        for (var i = 0; i < brainFuckCode.Length; i++)
        {
            i = ExecuteOneSymbol(brainFuckCode, i);
        }
    }

    public int ExecuteOneSymbol(string brainFuckCode, int i)
    {
        switch (brainFuckCode[i])
        {
            case '+':
                _brainFuckFunction.NextCharValue();
                break;
            case '-':
                _brainFuckFunction.PreviousCharValue();
                break;
            case '.':
                _brainFuckFunction.DisplayCellValue();
                break;
            case '>':
                _brainFuckFunction.NextCell();
                break;
            case '<':
                _brainFuckFunction.PreviousCell();
                break;
            case ',':
                _brainFuckFunction.InputValueInCell();
                break;
            case '[':
                i = _brainFuckFunction.IfZeroNext(i, brainFuckCode);
                break;
            case ']':
                i = _brainFuckFunction.IfNoZeroBack(i, brainFuckCode);
                break;
        }

        return i;
    }
}
