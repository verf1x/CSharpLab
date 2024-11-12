using CSLab.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CSLab.Modules;

/// <summary>
/// Represents the main class of the application
/// </summary>
internal class Application
{
    private readonly Menu _menu;
    private readonly ILogger _logger;
    private readonly SortsBenchmark<int> _sortsBenchmark;
    private readonly Tetris _tetris;
    private bool _isRunning;
    
    public Application(IServiceProvider serviceProvider)
    {
        _menu = serviceProvider.GetRequiredService<Menu>();
        _logger = serviceProvider.GetRequiredService<ILogger>();
        _sortsBenchmark = serviceProvider.GetRequiredService<SortsBenchmark<int>>();
        _tetris = serviceProvider.GetRequiredService<Tetris>();
    }
    
    /// <summary>
    /// Runs the application
    /// </summary>
    internal void Run()
    {
        _isRunning = true;
        
        while (_isRunning)
        {
            MoveToBlankPage();
            _menu.Display();

            Action menuAction = _menu.GetUserChoice() switch
            {
                1 => MathGame.Start,
                2 => PrintAuthor,
                3 => SortArray,
                4 => _tetris.Run,
                5 => Exit,
                _ => () => _logger.LogIncorrectInput()
            };
            
            MoveToBlankPage();
            menuAction?.Invoke();
        }
    }

    private void Exit()
    {
        _isRunning = !_menu.ConfirmExit();
    }

    private void MoveToBlankPage()
    {
        Console.Clear();
        ApplicationHelper.PrintTitle();
    }

    private void ReturnToMenuByPressingKey()
    {
        WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
        ReadKey();
    }
    
    private void PrintAuthor()
    {
        WriteLine("Автор\tКупцов Никита Александрович\tГруппа\t6102-090301D\n");
        ReturnToMenuByPressingKey();
    }

    private void SortArray()
    {
        bool isCorrectInput = false;

        while (!isCorrectInput)
        {
            
            // int[] arrayToSort = new ArrayTools(13).GetFilledWithNumbersArray();
            int[] arrayToSort = new ArrayTools().GetFilledWithNumbersArray();

            if (arrayToSort.Length > 0)
            {
                isCorrectInput = true;

                _sortsBenchmark.Run(arrayToSort);
                ReturnToMenuByPressingKey();
            }
        }
    }
}