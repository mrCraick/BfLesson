namespace BrainFuck.Interfaces.Menus;

public interface IMenuBuilder
{
    IMenuBuilder AddNewMenuLine(IMenuLine newMenuLine);
    IMenu Build();
}