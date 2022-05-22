public static class Program
{
    public static void Main()
    {
        Repository BrainFuckCode = new Repository();
        DataOperations dataOperations = new DataOperations(BrainFuckCode, new InputOutput(Console.In, Console.Out)) ;
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
public class DataOperations
{
    private Repository _dataFromRepository;
    private InputOutput _inputOutput;



    public DataOperations(
        Repository dataFromRepository,
        InputOutput inputOutput)
    {
        _dataFromRepository = dataFromRepository;
        _inputOutput = inputOutput;
    }
    public void EnumСodeBrainFuck(string BrainFuckCode)
    {
        for (int i = 0; i < BrainFuckCode.Length; i++)
        {
            switch (BrainFuckCode[i])
            {
                case '+':
                    NextCharValue();  //поменено местами
                    break;
                case '-':
                    PreviousCharValue();  //поменено местами
                    break;
                case '.':
                    DisplayCellValue();
                    break;
                case '>':
                    NextCell();
                    break;
                case '<':
                    PreviusCell();
                    break;
                case ',':
                    InputValueInCell();
                    break;
                case '[':
                    i = IfZeroNext(i, BrainFuckCode);
                    break;
                case ']':
                    i = IfNoZeroBack(i, BrainFuckCode);
                    break;
            }
        }
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
        if (_dataFromRepository.Current<_dataFromRepository.Memory.Length)
        {
            _dataFromRepository.Current = _dataFromRepository.Current + 1;
        }
        
    }
    public virtual void PreviusCell() // тест есть 
    {
        if (_dataFromRepository.Current>0)
        {
            _dataFromRepository.Current = _dataFromRepository.Current - 1;
        }
        
    }
    public virtual void InputValueInCell()
    {
        _dataFromRepository.Memory[_dataFromRepository.Current] = _inputOutput.GetCharUser();
    }
    public virtual int IfZeroNext(int PositionNumber, string BrainFuckCode) //тест есть
    {
        if (_dataFromRepository.Memory[_dataFromRepository.Current] == 0)
        {
            int NumberOfopenBrackets = 1;
            while (NumberOfopenBrackets != 0)
            {
                PositionNumber++;
                if (BrainFuckCode[PositionNumber] == '[')
                {
                    NumberOfopenBrackets++;
                }
                if (BrainFuckCode[PositionNumber] == ']')
                {
                    NumberOfopenBrackets--;
                }
            }
        }
        return PositionNumber;
    }
    public virtual int IfNoZeroBack(int PositionNumber, string BrainFuckCode) //тест есть
    {
        if (_dataFromRepository.Memory[_dataFromRepository.Current] != 0)
        {
            int NumberOfopenBrackets = 1;
            while (NumberOfopenBrackets != 0)
            {
                PositionNumber--;
                if (BrainFuckCode[PositionNumber] == ']')
                {
                    NumberOfopenBrackets++;
                }
                if (BrainFuckCode[PositionNumber] == '[')
                {
                    NumberOfopenBrackets--;
                }

            }
        }
        return PositionNumber;
    }

    
}

public class InputOutput
{
    private TextReader Reader;
    private TextWriter Writer;

    public  InputOutput (TextReader output, TextWriter input)
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

