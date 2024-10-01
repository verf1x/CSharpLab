using static System.Console;

namespace Lab2;

internal class GameHelper
{
    private const ConsoleColor _titleColor = ConsoleColor.Green;
    private readonly ConsoleColor _defaultColor;
    private static GameHelper _instance;

    public static GameHelper Instance => _instance ??= new GameHelper(ForegroundColor);

    public GameHelper(ConsoleColor defaultColor)
    {
        _defaultColor = defaultColor;
    }

    public void PrintTitle()
    {
        ForegroundColor = _titleColor;

        WriteLine("//------------------------//");
        WriteLine("// Супер крутая игра v1.1 //");
        WriteLine("//------------------------//\n");

        ForegroundColor = _defaultColor;
    }

    public void PrintMenu()
    {
        WriteLine("Меню\n");
        WriteLine("1. Отгадай ответ");
        WriteLine("2. Об авторе");
        WriteLine("3. Выход\n");
    }

    public void MoveToBlankPage()
    {
        Clear();
        PrintTitle();
    }
}
