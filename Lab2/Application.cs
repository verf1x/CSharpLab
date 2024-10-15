namespace Lab2;

using System.Collections.Generic;

internal class Application
{
    private static Application _instance;
    private Dictionary<int, (Action action, string name)> _menu = [];
    private bool _isExit = false;

    public static Application Instance => _instance ??= new();

    private Application()
    {
        InitializeMenu();
    }

    private void InitializeMenu()
    {
        _menu.Add(1, (GuessAnswer, "Отгадай ответ"));
        _menu.Add(2, (PrintAuthor, "Об авторе"));
        _menu.Add(3, (SortArray, "Сортировка массива"));
        _menu.Add(4, (() => _isExit = ConfirmExit(), "Выход\n"));
    }

    public void Run()
    {
        bool isExit = false;

        while (!isExit)
        {
            DrawMenu();

            if (int.TryParse(ReadLine(), out int choice))
            {
                if (_menu.ContainsKey(choice))
                    _menu[choice].action?.Invoke();
                else
                    ApplicationHelper.Instance.LogIvalidInput();
            }
        }
    }

    public void DrawMenu()
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
        ReturnToMenu();
    }

    private void SortArray()
    {
        bool isCorrectInput = false;

        while (!isCorrectInput)
        {
            if(ArrayTools.TryGetArray(out int[] array))
            {
                isCorrectInput = true;

                ArrayTools.FillNumbersArray(array);
                ArrayTools.SetupSortingBenchmark(array);
            }
        }
    }

    private bool ConfirmExit()
    {
        MoveToBlankPage();

        WriteLine("Вы уверены, что хотите выйти? (д/н): ");

        string input = ReadLine().ToLower();

        while (input != "д" && input != "н")
        {
            MoveToBlankPage();

            ApplicationHelper.Instance.LogError("Ошибка ввода. Введите 'д' или 'н'.");
            Write("Вы уверены, что хотите выйти? (д/н): ");
            input = ReadLine().ToLower();
        }

        return input == "д";
    }

    public void MoveToBlankPage()
    {
        Console.Clear();
        ApplicationHelper.Instance.PrintTitle();
    }

    private void ReturnToMenu()
    {
        WriteLine("\nВозвращение в меню...");
        Thread.Sleep(800);
    }
}
