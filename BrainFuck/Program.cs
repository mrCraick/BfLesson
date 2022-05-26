public static class Program
{
    public static void Main()
    {
        Repository BrainFuckCode = new Repository();
        var brainFuckFunction = new BrainFuckFunction(BrainFuckCode, new InputOutput(Console.In, Console.Out));
        DataOperations dataOperations = new DataOperations(brainFuckFunction);
        dataOperations.EnumСodeBrainFuck(BrainFuckCode.Program);

    }
}

public class Repository
{
    public char[] Memory { get; set; }
    public int Current { get; set; }
    public string Program { get; set; }
    public Repository()
    {
        Memory = new char[30000];
        Current = 0;
        Program = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";
    }

}

public interface IBrainFuckFunction
{
    void NextCharValue();
    void PreviousCharValue();
    void DisplayCellValue();
    void NextCell();
    void PreviusCell();
    void InputValueInCell();
    int IfZeroNext(int positionNumber, string brainFuckCode);
    int IfNoZeroBack(int positionNumber, string brainFuckCode);
}

public class BrainFuckFunction : IBrainFuckFunction
{
    private Repository _dataFromRepository;
    private InputOutput _inputOutput;

    public BrainFuckFunction(Repository dataFromRepository, InputOutput inputOutput)
    {
        _dataFromRepository = dataFromRepository;
        _inputOutput = inputOutput;
    }

    public virtual void NextCharValue() //тест есть
    {
        _dataFromRepository.Memory[_dataFromRepository.Current]++;
        // так не рабит нихуя
        //dataFromRepository.Memory[dataFromRepository.Current] = Convert.ToChar(Convert.ToInt32(dataFromRepository.Memory[dataFromRepository.Current]) + 1);
    }
    public virtual void PreviousCharValue() // тест есть
    {

        _dataFromRepository.Memory[_dataFromRepository.Current]--;
        // так не рабит нихуя
        // dataFromRepository.Memory[dataFromRepository.Current] = Convert.ToChar(Convert.ToInt32(dataFromRepository.Memory[dataFromRepository.Current]) - 1);

    }
    public virtual void DisplayCellValue() //тест есть 
    {
        _inputOutput.OutputConsole(Convert.ToString(_dataFromRepository.Memory[_dataFromRepository.Current]));
    }
    public virtual void NextCell() //тест есть 
    {
        if (_dataFromRepository.Current < _dataFromRepository.Memory.Length)
        {
            _dataFromRepository.Current = _dataFromRepository.Current + 1;
        }

    }
    public virtual void PreviusCell() // тест есть 
    {
        if (_dataFromRepository.Current > 0)
        {
            _dataFromRepository.Current = _dataFromRepository.Current - 1;
        }

    }
    public virtual void InputValueInCell()
    {
        _dataFromRepository.Memory[_dataFromRepository.Current] = _inputOutput.GetCharUser();
    }
    public virtual int IfZeroNext(int positionNumber, string brainFuckCode) //тест есть
    {
        if (_dataFromRepository.Memory[_dataFromRepository.Current] == 0)
        {
            int NumberOfopenBrackets = 1;
            while (NumberOfopenBrackets != 0)
            {
                positionNumber++;
                if (brainFuckCode[positionNumber] == '[')
                {
                    NumberOfopenBrackets++;
                }
                if (brainFuckCode[positionNumber] == ']')
                {
                    NumberOfopenBrackets--;
                }
            }
        }
        return positionNumber;
    }
    public virtual int IfNoZeroBack(int positionNumber, string brainFuckCode) //тест есть
    {
        if (_dataFromRepository.Memory[_dataFromRepository.Current] != 0)
        {
            int NumberOfopenBrackets = 1;
            while (NumberOfopenBrackets != 0)
            {
                positionNumber--;
                if (brainFuckCode[positionNumber] == ']')
                {
                    NumberOfopenBrackets++;
                }
                if (brainFuckCode[positionNumber] == '[')
                {
                    NumberOfopenBrackets--;
                }

            }
        }
        return positionNumber;
    }
}

public class DataOperations
{
    private IBrainFuckFunction _brainFuckFunction;

    public DataOperations(IBrainFuckFunction brainFuckFunction)
    {
        _brainFuckFunction = brainFuckFunction;
    }

    public void EnumСodeBrainFuck(string brainFuckCode)
    {
        for (int i = 0; i < brainFuckCode.Length; i++)
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
                    _brainFuckFunction.PreviusCell();
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
        }
    }


}

public class InputOutput
{
    private TextReader Reader;
    private TextWriter Writer;

    public InputOutput(TextReader output, TextWriter input)
    {
        Reader = output;
        Writer = input;

    }

    public char GetCharUser()
    {
        while (true)
        {
            string userInput = GetStringUser();
            if (char.TryParse(userInput, out char result))
            {
                return result;
            }
        }

    }

    public string GetStringUser()
    {

        return Reader.ReadLine();
    }
    public void OutputConsole(string messageOrChar)
    {
        Writer.Write(messageOrChar);
    }

}

