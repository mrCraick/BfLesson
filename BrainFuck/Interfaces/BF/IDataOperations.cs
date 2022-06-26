namespace BrainFuck.Interfaces.BF;

public interface IDataOperations
{
    void EnumСodeBrainFuck(string brainFuckCode);
    int ExecuteOneSymbol(string brainFuckCode, int i);
}