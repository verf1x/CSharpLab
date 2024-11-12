namespace CSLab.Interfaces;

/// <summary>
/// Interface for logging
/// </summary>
internal interface ILogger
{
    /// <summary>
    /// Logging message as information
    /// </summary>
    /// <param name="message"></param>
    void LogInformation(string message);
    
    /// <summary>
    /// Logging message as warning
    /// </summary>
    /// <param name="message"></param>
    void LogWarning(string message);
    
    /// <summary>
    /// Logging message as error
    /// </summary>
    /// <param name="message"></param>
    void LogError(string message);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    void LogIncorrectInput(string message = null);
}