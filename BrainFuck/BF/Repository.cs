namespace BrainFuck.BF;

public class Repository
{
    public char[] Memory { get; }
    public int Current { get; set; }
    public string Program { get; }

    public Repository() : 
        this("++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.")
    {
        
    }

    public Repository(string program)
    {
        Memory = new char[30000];
        Current = 0;
        Program = program;
    }
}
