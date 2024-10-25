namespace Lab2;

internal class SimpleLogger
{
    private static SimpleLogger _instance;
    public static SimpleLogger Instance => _instance ??= new SimpleLogger();

    private SimpleLogger() { }
    
    public void LogInformation(string message)
    {
        WriteLine($"{message}\n");
    }

    public void LogWarning(string message)
    {
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine($"{message}\n");
    }

    public void LogError(string message)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"{message}\n");
        ForegroundColor = ApplicationHelper.Instance.DefaultColor;
    }

    public void LogIncorrectInput(string message = "Неправильный ввод. Попробуйте снова.")
        => LogError(message);
}