public static class Program
{
    private static char[] _memory;
    private static int _current = 0;

    public static void Main()
    {
        _memory = new char[30000];

        string program =
            "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++.+++++++++++++++++++++++++++++.+++++++..+++.-------------------------------------------------------------------------------.+++++++++++++++++++++++++++++++++++++++++++++++++++++++.++++++++++++++++++++++++.+++.------.--------.-------------------------------------------------------------------.-----------------------.";

        foreach (var item in program)
        {
            if (item == '+')
            {
                NextCharValue();
            }
            if (item == '-')
            {
                PreviousCharValue();
            }
            if (item == '.')
            {
                DisplayCellValue();
            }
            if (item == '>')
            {
                NextCell();
            }
            if (item == '<')
            {
                PreviusCell();
            }
            if (item == ',')
            {
                InputValueInCell();
            }
            if (item == '[')
            {
                IfZeroNext();
            }
            if (item == ']')
            {
                IfNoZeroBack();
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

    public static void IfZeroNext()
    {
        while (_memory[_current] == 0)
        {
            _current++;
        }
    }

    public static void IfNoZeroBack()
    {
        while (_memory[_current] != 0)
        {
            _current--;
        }
    }
}
