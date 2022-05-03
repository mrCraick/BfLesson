public static class Program
{
    public static void Main()
    {
        Repository BrainFuckCode = new Repository();
        DataOperations dataOperations = new DataOperations();
        dataOperations.enumСodeBrainFuck(BrainFuckCode.Program);

    }
}

public class Repository
{
    private char[] _memory;
    private int _current;
    private string _program;
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
    Repository dataFromRepository = new Repository();
    InputOutput inputOutput = new InputOutput();
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
    public void NextCharValue()
    {
        dataFromRepository.Memory[dataFromRepository.Current]++;
      // так не рабит нихуя
      //dataFromRepository.Memory[dataFromRepository.Current] = Convert.ToChar(Convert.ToInt32(dataFromRepository.Memory[dataFromRepository.Current]) + 1);
    }

    public void PreviousCharValue()
    {

        dataFromRepository.Memory[dataFromRepository.Current]--;
        // так не рабит нихуя
        // dataFromRepository.Memory[dataFromRepository.Current] = Convert.ToChar(Convert.ToInt32(dataFromRepository.Memory[dataFromRepository.Current]) - 1);

    }
    public void DisplayCellValue()
    {
        inputOutput.OutputConsole(Convert.ToString(dataFromRepository.Memory[dataFromRepository.Current]));
    }
    public void NextCell()
    {
        if (dataFromRepository.Current<dataFromRepository.Memory.Length)
        {
            dataFromRepository.Current = dataFromRepository.Current + 1;
        }
        
    }
    public void PreviusCell()
    {
        if (dataFromRepository.Current>0)
        {
            dataFromRepository.Current = dataFromRepository.Current - 1;
        }
        
    }
    public void InputValueInCell()
    {
        dataFromRepository.Memory[dataFromRepository.Current] = inputOutput.GetCharUser();
    }
    public int IfZeroNext(int PositionNumber, string BrainFuckCode)
    {
        if (dataFromRepository.Memory[dataFromRepository.Current] == 0)
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
        return PositionNumber + 1;
    }
    public int IfNoZeroBack(int PositionNumber, string BrainFuckCode)
    {
        if (dataFromRepository.Memory[dataFromRepository.Current] != 0)
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
        return PositionNumber - 1;
    }

    
}

public class InputOutput
{
    public char GetCharUser()
    {
        while (true)
        {
            string userInput = GetStringUser();
            if (char.TryParse(userInput, out char result))
            {
                return result;
            }
            // А так можно?
            //if (char.TryParse(GetStringUser(), out char result))
            //{
            //    return result;
            //}
        }
    }
    public string GetStringUser()
    {
        return Console.ReadLine();
    }
    public void OutputConsole(string messageOrChar)
    {
        Console.WriteLine(messageOrChar);
    }

}