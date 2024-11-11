namespace CSLab.Modules;

internal class ApplicationHelper
{
    internal static ConsoleColor DefaultColor => ConsoleColor.Gray;

    internal void PrintTitle()
    {
        ForegroundColor = ConsoleColor.Green;

        WriteLine("//------------------------//");
        WriteLine("// Супер крутая игра v1.1 //");
        WriteLine("//------------------------//\n");

        ForegroundColor = DefaultColor;
    }
}
