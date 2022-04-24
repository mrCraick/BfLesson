public static class Program
{
    private static char[] _memory;
    private static int _current = 0;

    public static void Main()
    {
        _memory = new char[30000];

        string program =
            "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";

        foreach (var item in program)
        {
            switch (item)
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
                    IfZeroNext(item);
                    break;
                case ']':
                    IfNoZeroBack(item);
                    break;
            }
        }

    }

    public static void NextCharValue()
    {
        _memory[_current]++;
    }

    public static void PreviousCharValue()
    {
        _memory[_current]--;
    }
    public static void DisplayCellValue()
    {
        Console.Write(_memory[_current]);
    }
    public static void NextCell()
    {
        _current++;
    }
    public static void PreviusCell()
    {
        _current--;
    }

    public static void InputValueInCell()
    {
        _memory[_current] = Convert.ToChar(Console.ReadLine());
    }

    /// <summary>
    /// если значение текущей ячейки ноль,
    /// перейти вперёд по тексту программы на ячейку, следующую за соответствующей ] (с учётом вложенности)
    /// </summary>
    public static void IfZeroNext(char item)
    {
        if (_memory[_current] == 0)
        {
            int NumberOfopenBrackets = 1;
            while (NumberOfopenBrackets != 0)
            {
                _current++;
                if (item == '[')
                {
                    NumberOfopenBrackets++;
                }
                if (item == ']')
                {
                    NumberOfopenBrackets--;
                }
            }
        }
    }



    public static void IfNoZeroBack(char item)
    {
        if (_memory[_current] != 0)
        {
            int NumberOfCloseBrackets = 1;
            {
                while (NumberOfCloseBrackets != 0)
                {
                    _current--;
                    if (item == ']')
                    { 
                        NumberOfCloseBrackets++;
                    }
                    if (item == '[')
                    { 
                        NumberOfCloseBrackets--;
                    }
                }
                
            }
        }

    }
}
