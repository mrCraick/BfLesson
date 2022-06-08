namespace BrainFuck.Interfaces.BF;

public interface IBrainFuckFunction
{
    void NextCharValue();
    void PreviousCharValue();
    void DisplayCellValue();
    void NextCell();
    void PreviousCell();
    void InputValueInCell();
    int IfZeroNext(int positionNumber, string brainFuckCode);
    int IfNoZeroBack(int positionNumber, string brainFuckCode);
}