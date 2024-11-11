global using static System.Console;

using System.Text;
using CSLab.Interfaces;
using CSLab.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace CSLab;

internal class Program
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
        services.AddSingleton<ApplicationHelper>();
        services.AddSingleton<InputHandler>();
        services.AddSingleton<ILogger, SimpleLogger>();
        services.AddSingleton<IMenuService, Menu>();
        services.AddSingleton<ArrayTools>();
        services.AddSingleton<MathGame>();
        services.AddSingleton(typeof(SortsBenchmark<>));
    }

    private static void SetupEncodingAndCulture()
    {
        InputEncoding = Encoding.UTF8;
        OutputEncoding = Encoding.UTF8;

        Thread.CurrentThread.CurrentCulture = new("ru-RU");
    }
}
