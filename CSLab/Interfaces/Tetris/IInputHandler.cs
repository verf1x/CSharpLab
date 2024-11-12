namespace CSLab.Modules;

/// <summary>
/// Input handler interface
/// </summary>
internal interface IInputHandler
{
    /// <summary>
    /// Handle the input and return the key
    /// </summary>
    /// <returns></returns>
    ConsoleKey? GetInput();
}