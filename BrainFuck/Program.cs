public static class Program
{
    public static void Main()
    {
        Repository BrainFuckCode = new Repository();
        DataOperations dataOperations = new DataOperations(BrainFuckCode, new InputOutput(Console.In, Console.Out)) ;
        dataOperations.enumСodeBrainFuck(BrainFuckCode.Program);

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
    private Repository _dataFromRepository = new Repository();
    private InputOutput _inputOutput = new InputOutput(Console.In, Console.Out);



    public DataOperations(
        Repository dataFromRepository,
        InputOutput inputOutput)
    {
        _dataFromRepository = dataFromRepository;
        _inputOutput = inputOutput;
    }
    public void enumСodeBrainFuck(string BrainFuckCode)
    {
        for (int i = 0; i < BrainFuckCode.Length; i++)
        {
            switch (BrainFuckCode[i])
            {
                case '+':
                    NextCharValue();
                    break;
                case '-':
                    PreviousCharValue();
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
    public void NextCharValue() //тест есть
    {
        _dataFromRepository.Memory[_dataFromRepository.Current]++;
      // так не рабит нихуя
      //dataFromRepository.Memory[dataFromRepository.Current] = Convert.ToChar(Convert.ToInt32(dataFromRepository.Memory[dataFromRepository.Current]) + 1);
    }

    public void PreviousCharValue() // тест есть
    {

        _dataFromRepository.Memory[_dataFromRepository.Current]--;
        // так не рабит нихуя
        // dataFromRepository.Memory[dataFromRepository.Current] = Convert.ToChar(Convert.ToInt32(dataFromRepository.Memory[dataFromRepository.Current]) - 1);

    }
    public void DisplayCellValue() //тест есть 
    {
        _inputOutput.OutputConsole(Convert.ToString(_dataFromRepository.Memory[_dataFromRepository.Current]));
    }
    public void NextCell() //тест есть 
    {
        if (_dataFromRepository.Current<_dataFromRepository.Memory.Length)
        {
            _dataFromRepository.Current = _dataFromRepository.Current + 1;
        }
        
    }
    public void PreviusCell() // тест есть 
    {
        if (_dataFromRepository.Current>0)
        {
            _dataFromRepository.Current = _dataFromRepository.Current - 1;
        }
        
    }
    public void InputValueInCell()
    {
        _dataFromRepository.Memory[_dataFromRepository.Current] = _inputOutput.GetCharUser();
    }
    public int IfZeroNext(int PositionNumber, string BrainFuckCode) //тест есть
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
    public int IfNoZeroBack(int PositionNumber, string BrainFuckCode) //тест есть
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

