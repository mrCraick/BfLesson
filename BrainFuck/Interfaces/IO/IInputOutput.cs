namespace BrainFuck.Interfaces.IO;

public interface IInputOutput
{
    char GetCharUser();
    string GetStringUser();
    void OutputConsole(string messageOrChar);
}