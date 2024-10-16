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

    public void LogError(string message)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(message + "\n");
        ForegroundColor = _defaultColor;

        Thread.Sleep(500);
    }

    public void LogIncorrectInput()
        => LogError("Неправильный ввод. Возможно, вы использовали некорректный разделитель. Попробуйте снова.");

    public void LogInvalidInput() 
        => LogError("Неправильный ввод. Попробуйте снова.");
}
