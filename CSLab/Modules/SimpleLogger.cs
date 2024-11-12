using CSLab.Interfaces;

namespace CSLab.Modules;

/// <summary>
/// Simple implementation of ILogger
/// </summary>
internal class SimpleLogger : ILogger
{
    void ILogger.LogInformation(string message)
    {
        WriteLine($"{message}\n");
    }

    void ILogger.LogWarning(string message)
    {
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine($"{message}\n");
    }

    void ILogger.LogError(string message)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"{message}\n");
        ForegroundColor = ApplicationHelper.DefaultColor;
    }

    void ILogger.LogIncorrectInput(string message)
    {
        if (message is null)
            WriteLine("Некорректный ввод\n");
        else
            ((ILogger)this).LogError(message);
    }
}