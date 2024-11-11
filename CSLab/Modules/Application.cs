using CSLab.Interfaces;

namespace CSLab.Modules;

internal class Application
{
    private readonly IMenuService _menu;
    private readonly ILogger _logger;
    private readonly ApplicationHelper _applicationHelper;
    private readonly ArrayTools _arrayTools;
    private readonly MathGame _mathGame;
    private readonly SortsBenchmark<int> _sortsBenchmark;
    private bool _isRunning;
    
    public Application(IMenuService menuService, ILogger logger, ApplicationHelper applicationHelper, ArrayTools arrayTools, MathGame mathGame, SortsBenchmark<int> sortsBenchmark)
    {
        _menu = menuService;
        _logger = logger;
        _applicationHelper = applicationHelper;
        _arrayTools = arrayTools;
        _mathGame = mathGame;
        _sortsBenchmark = sortsBenchmark;
    }
    
    internal void Run()
    {
        _isRunning = true;
        
        while (_isRunning)
        {
            MoveToBlankPage();
            _menu.Display();

            Action menuAction = _menu.GetUserChoice() switch
            {
                1 => _mathGame.Start,
                2 => PrintAuthor,
                3 => SortArray,
                4 => Exit,
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
        _applicationHelper.PrintTitle();
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
            int[] arrayToSort = _arrayTools.GetFilledWithNumbersArray();

            if (arrayToSort.Length > 0)
            {
                isCorrectInput = true;

                _sortsBenchmark.Run(arrayToSort);
                ReturnToMenuByPressingKey();
            }
        }
    }
}