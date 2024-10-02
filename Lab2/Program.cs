global using static System.Console;
using System.Text;

namespace Lab2;

internal class Program
{
    private static void Main(string[] args)
    {
        InputEncoding = Encoding.UTF8;
        OutputEncoding = Encoding.UTF8;

        Thread.CurrentThread.CurrentCulture = new("ru-RU");

        Application.Instance.Run();
    }
}
