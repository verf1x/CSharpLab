global using static System.Console;
using System.Text;
using CSLab.Interfaces;
using CSLab.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace CSLab;

file class Program
{
    private static void Main(string[] args)
    {
        SetupEncodingAndCulture();
        
        ServiceCollection services = new();
        ConfigureServices(services);

        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        
        var appService = serviceProvider.GetRequiredService<Application>();
        appService.Run();
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<Application>();
        services.AddSingleton<ILogger, SimpleLogger>();
        services.AddSingleton<Menu>();
        services.AddSingleton(typeof(SortsBenchmark<>));
        services.AddSingleton<Tetris>();
        services.AddSingleton<Piece>();
        services.AddSingleton<IBoard, Board>();
        services.AddSingleton<IInputHandler, ConsoleInputHandler>();
        services.AddSingleton<IRenderer, ConsoleRenderer>();
        services.AddSingleton<IPieceGenerator, PieceGenerator>();
        services.AddSingleton<IScoreManager, ScoreManager>();
    }

    private static void SetupEncodingAndCulture()
    {
        InputEncoding = Encoding.UTF8;
        OutputEncoding = Encoding.UTF8;

        Thread.CurrentThread.CurrentCulture = new("ru-RU");
    }
}
