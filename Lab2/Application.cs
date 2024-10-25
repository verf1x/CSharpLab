namespace Lab2;

internal class Application
{
    private static Application _instance;
    private readonly Menu _menu;
    private bool _isExit = false;

    public static Application Instance => _instance ??= new();

    private Application()
    {
        _menu = new Menu();
    }

    public void Run()
    {
        while (!_isExit)
        {
            _menu.ShowMenu();
            _menu.HandleUserChoice();
        }
    }

    public void Exit()
    {
        _isExit = ConfirmExit();
    }

    private bool ConfirmExit()
    {
        MoveToBlankPage();
        
        bool exit = false;
        bool isConfirmed = false;
    
        do
        {
            WriteLine("Вы уверены, что хотите выйти? (д/н): ");
        
            string answer = ReadLine()?.ToLower();

            if (answer is "д")
            {
                exit = true;
                isConfirmed = true;
            }
            else if (answer is "н")
            {
                exit = false;
                isConfirmed = true;
            }
            else
            {
                MoveToBlankPage();
                SimpleLogger.Instance.LogIncorrectInput("Ошибка ввода. Введите 'д' или 'н'.");
            }
        } while (!isConfirmed);
        
        return exit;
    }

    public void MoveToBlankPage()
    {
        Console.Clear();
        ApplicationHelper.Instance.PrintTitle();
    }

    public void ReturnToMenuWithDelay()
    {
        WriteLine("\nВозвращение в меню...");
        Thread.Sleep(1000);
    }
    
    public void ReturnToMenuByPressingKey()
    {
        WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
        ReadKey();
    }
}