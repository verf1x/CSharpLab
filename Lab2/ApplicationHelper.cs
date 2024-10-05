namespace Lab2;

internal class ApplicationHelper
{
    private const ConsoleColor _titleColor = ConsoleColor.Green;
    private readonly ConsoleColor _defaultColor;
    private static ApplicationHelper _instance;

    public static ApplicationHelper Instance => _instance ??= new ApplicationHelper(ForegroundColor);

    private ApplicationHelper(ConsoleColor defaultColor)
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

    public void LogError(string message)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(message + "\n");
        ForegroundColor = _defaultColor;

        Thread.Sleep(1000);
    }
}
