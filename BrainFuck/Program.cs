public static class Program
{


    public static void Main()
    {
        Repository BrainFuckCode = new Repository();
        DataOperations dataOperations = new DataOperations();
        dataOperations.enumСodeBrainFuck(BrainFuckCode.program);

    }
}

public class Repository
{
    public char[] _memory = new char[30000];
    public int _current = 0;
    //
    public string program = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";
   
    //"++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++.+++++++++++++++++++++++++++++.+++++++..+++.-------------------------------------------------------------------------------.+++++++++++++++++++++++++++++++++++++++++++++++++++++++.++++++++++++++++++++++++.+++.------.--------.-------------------------------------------------------------------.----------------------*/ -.";
}

public class DataOperations : Repository
{

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
        _memory[_current]++;
    }

    public void PreviousCharValue()
    {
        _memory[_current]--;
    }
    public void DisplayCellValue()
    {
        Console.Write(_memory[_current]);
    }
    public void NextCell()
    {
        _current++;
    }
    public void PreviusCell()
    {
        _current--;
    }
    public void InputValueInCell()
    // сделать ввод массива чаров - Так, стоп, а нахрена? Если у нас прием значения для одной ячейки, а не массива?

    {
        _memory[_current] = Convert.ToChar(Console.ReadLine()); 
    }
    public int IfZeroNext(int PositionNumber, string BrainFuckCode)
    {
        if (_memory[_current] == 0)
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
        if (_memory[_current] != 0)
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
        return PositionNumber-1;
    }
}
