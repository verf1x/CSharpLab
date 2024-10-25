global using static System.Console;

namespace Lab2;

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Setup();

        Application.Instance.Run();
    }

    private static void Setup()
    {
        InputEncoding = Encoding.UTF8;
        OutputEncoding = Encoding.UTF8;

        Thread.CurrentThread.CurrentCulture = new("ru-RU");
    }
}
