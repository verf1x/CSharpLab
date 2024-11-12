namespace CSLab.Modules;

/// <summary>
/// Simple console Input handler
/// </summary>
internal class ConsoleInputHandler : IInputHandler
{
    ConsoleKey? IInputHandler.GetInput()
    {
        if (Console.KeyAvailable)
        {
            var keyInfo = Console.ReadKey(true);
            return keyInfo.Key;
        }
        return null;
    }
}