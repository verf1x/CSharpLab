namespace Lab2;

internal class Application
{
    private static Application _instance;
    private readonly Dictionary<int, (Action action, string name)> _menu = [];
    private bool _isExit = false;

    public static Application Instance => _instance ??= new();

    private Application()
    {
        InitializeMenu();
    }

    private void InitializeMenu()
    {
        _menu.Add(2, (PrintAuthor, "Об авторе"));
        _menu.Add(3, (SortArray, "Сортировка массива"));
        _menu.Add(4, (() => _isExit = ConfirmExit(), "Выход\n"));
    }

    public void Run()
    {
        bool isExit = false;

        while (!isExit)
        {
            ShowMenu();

            if (int.TryParse(ReadLine(), out int choice))
            {
                if (_menu.ContainsKey(choice))
                    _menu[choice].action?.Invoke();
                else
                    ApplicationHelper.Instance.LogInvalidInput();
            }
        }
    }

    public void ShowMenu()
    {
        MoveToBlankPage();

        foreach (var item in _menu)
            WriteLine($"{item.Key}. {item.Value.name}");
    }

    private void GuessAnswer()
    {
        MoveToBlankPage();
        Game.Instance.Start();
    }

    private void PrintAuthor()
    {
        MoveToBlankPage();
        WriteLine("Автор\tКупцов Никита Александрович\tГруппа\t6102-090301D\n");
        WriteLine("Нажмите любую клавишу для возврата в меню...");
        ReadKey();
        ReturnToMenuWithDelay();
    }

    private void SortArray()
    {
        bool isCorrectInput = false;

        while (!isCorrectInput)
        {
            int[] arrayToSort = ArrayTools.GetArray();

            if (arrayToSort.Length > 0)
            {
                isCorrectInput = true;

                ArrayTools.FillNumbersArray(arrayToSort);
                ArrayTools.SetupSortingBenchmark(arrayToSort);
            }
        }
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
                ApplicationHelper.Instance.LogError("Ошибка ввода. Введите 'д' или 'н'.");
            }
        } while (!isConfirmed);
        
        return exit;
    }

    public void MoveToBlankPage()
    {
        Console.Clear();
        ApplicationHelper.Instance.PrintTitle();
    }

    private void ReturnToMenuWithDelay()
    {
        WriteLine("\nВозвращение в меню...");
        Thread.Sleep(1000);
    }
    
    private void ReturnToMenuByPressingKey()
    {
        WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
        ReadKey();
    }
}
