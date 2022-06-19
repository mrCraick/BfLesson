using BrainFuck.Interfaces.BF;

namespace BrainFuck.BF;

public class DataOperations : IDataOperations
{
    private int _index;

    public int Index
    {
        get => _index;
        set => _index = value;
    }

    public bool DebugMode { get; set; }


    private readonly IBrainFuckFunction _brainFuckFunction;

    public DataOperations(IBrainFuckFunction brainFuckFunction, DebugModeSwitch debugModeSwitch)
    {
        _brainFuckFunction = brainFuckFunction;
        DebugMode = debugModeSwitch.Enablded;
    }

    public DataOperations(IBrainFuckFunction brainFuckFunction)
    {
        _brainFuckFunction = brainFuckFunction;
    }

    public void EnumСodeBrainFuck(string brainFuckCode)
    {
        for (; _index < brainFuckCode.Length;)
        {
            switch (brainFuckCode[_index])
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
                    _index = _brainFuckFunction.IfZeroNext(_index, brainFuckCode);
                    break;
                case ']':
                    _index = _brainFuckFunction.IfNoZeroBack(_index, brainFuckCode);
                    break;
            }

            if (DebugMode == false)
            {
                _index += 1;
            }
            else
            {
                break;
            }
        }
    }
}
