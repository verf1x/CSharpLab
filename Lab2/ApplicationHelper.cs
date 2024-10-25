namespace Lab2;

internal class ApplicationHelper
{
    public ConsoleColor TitleColor => ConsoleColor.Green;
    public ConsoleColor DefaultColor => ConsoleColor.Gray;
    
    private static ApplicationHelper _instance;

    public static ApplicationHelper Instance => _instance ??= new();

    private ApplicationHelper() { }

    public void PrintTitle()
    {
        ForegroundColor = TitleColor;

        WriteLine("//------------------------//");
        WriteLine("// Супер крутая игра v1.1 //");
        WriteLine("//------------------------//\n");

        ForegroundColor = DefaultColor;
    }
}
