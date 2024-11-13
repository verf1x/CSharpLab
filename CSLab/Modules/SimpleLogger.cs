using CSLab.Interfaces;

namespace CSLab.Modules;

/// <summary>
/// Simple implementation of ILogger
/// </summary>
internal class SimpleLogger : ILogger
{
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
        ForegroundColor = ApplicationHelper.DefaultColor;
    }

    public void LogIncorrectInput(string message)
    {
        if (message is null)
            WriteLine("Некорректный ввод\n");
        else
            ((ILogger)this).LogError(message);
    }
}