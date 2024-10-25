namespace Lab2;

internal interface ILogger
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message);
    void LogIncorrectInput(string message);
}