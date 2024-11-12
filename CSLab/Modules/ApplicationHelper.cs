namespace CSLab.Modules;

/// <summary>
/// Application helper class
/// </summary>
internal static class ApplicationHelper
{
    internal static ConsoleColor DefaultColor => ConsoleColor.Gray;

    /// <summary>
    /// Print logo of the game
    /// </summary>
    internal static void PrintTitle()
    {
        ForegroundColor = ConsoleColor.Green;

        WriteLine("//------------------------//");
        WriteLine("// Супер крутая игра v1.1 //");
        WriteLine("//------------------------//\n");

        ForegroundColor = DefaultColor;
    }
}
