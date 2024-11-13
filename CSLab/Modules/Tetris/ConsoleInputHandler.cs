namespace CSLab.Modules;

/// <summary>
/// Simple console Input handler
/// </summary>
internal class ConsoleInputHandler : IInputHandler
{
    public ConsoleKey? GetInput()
    {
        if (!Console.KeyAvailable) 
            return null;
        
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        return keyInfo.Key;
    }
}