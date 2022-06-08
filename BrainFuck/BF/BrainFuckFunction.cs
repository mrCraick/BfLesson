using BrainFuck.Interfaces.BF;
using BrainFuck.Interfaces.IO;

namespace BrainFuck.BF;

public class BrainFuckFunction : IBrainFuckFunction
{
    private readonly Repository _dataFromRepository;
    private readonly IInputOutput _inputOutput;

    public BrainFuckFunction(Repository dataFromRepository, IInputOutput inputOutput)
    {
        _dataFromRepository = dataFromRepository;
        _inputOutput = inputOutput;
    }

    public virtual void NextCharValue()
    {
        _dataFromRepository.Memory[_dataFromRepository.Current]++;
    }

    public virtual void PreviousCharValue()
    {
        _dataFromRepository.Memory[_dataFromRepository.Current]--;
    }

    public virtual void DisplayCellValue()
    {
        _inputOutput.OutputConsole(Convert.ToString(_dataFromRepository.Memory[_dataFromRepository.Current]));
    }

    public virtual void NextCell() 
    {
        if (_dataFromRepository.Current < _dataFromRepository.Memory.Length)
        {
            _dataFromRepository.Current += 1;
        }
    }

    public virtual void PreviousCell()
    {
        if (_dataFromRepository.Current > 0)
        {
            _dataFromRepository.Current -= 1;
        }
    }

    public virtual void InputValueInCell()
    {
        _dataFromRepository.Memory[_dataFromRepository.Current] = _inputOutput.GetCharUser();
    }

    public virtual int IfZeroNext(int positionNumber, string brainFuckCode)
    {
        if (_dataFromRepository.Memory[_dataFromRepository.Current] == 0)
        {
            var numberOfOpenBrackets = 1;
            while (numberOfOpenBrackets != 0)
            {
                positionNumber++;
                if (brainFuckCode[positionNumber] == '[')
                {
                    numberOfOpenBrackets++;
                }

                if (brainFuckCode[positionNumber] == ']')
                {
                    numberOfOpenBrackets--;
                }
            }
        }

        return positionNumber;
    }

    public virtual int IfNoZeroBack(int positionNumber, string brainFuckCode)
    {
        if (_dataFromRepository.Memory[_dataFromRepository.Current] != 0)
        {
            var numberOfOpenBrackets = 1;
            while (numberOfOpenBrackets != 0)
            {
                positionNumber--;
                if (brainFuckCode[positionNumber] == ']')
                {
                    numberOfOpenBrackets++;
                }

                if (brainFuckCode[positionNumber] == '[')
                {
                    numberOfOpenBrackets--;
                }
            }
        }

        return positionNumber;
    }
}
