namespace BrainFuck.Interfaces.Menus;

public interface IMenuLine
{
    string Name { get; }
    void Execute();
}