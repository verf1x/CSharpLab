namespace Lab2;

internal class Application
{
    private static Application _instance;

    public static Application Instance => _instance ??= new Application();

    private Application() { }

    public void Run()
    {
        bool isExit = false;

        while (!isExit)
        {
            MoveToBlankPage();
            ApplicationHelper.Instance.PrintMenu();

            if (int.TryParse(ReadLine(), out int choice))
            {
                Action menuAction = choice switch
                {
                    1 => PlayGame,
                    2 => PrintAuthor,
                    3 => () => isExit = ConfirmExit(),
                    _ => () => WriteLine("Неверный выбор. Попробуйте снова."),
                };

                menuAction?.Invoke();
            }
        }

        MoveToBlankPage();
    }

    public void MoveToBlankPage()
    {
        Console.Clear();
        ApplicationHelper.Instance.PrintTitle();
    }

    private void PlayGame()
    {
        MoveToBlankPage();
        Game.Instance.Start();
    }

    private void ReturnToMenu()
    {
        WriteLine("Возвращение в меню...");
        Thread.Sleep(2000);
    }

    private void PrintAuthor()
    {
        MoveToBlankPage();
        WriteLine("Автор\tКупцов Никита Александрович\tГруппа\t6102-090301D\n");
        WriteLine("Нажмите любую клавишу для возврата в меню...");
        ReadKey();
        ReturnToMenu();
    }

    private bool ConfirmExit()
    {
        MoveToBlankPage();

        WriteLine("Вы уверены, что хотите выйти? (д/н): ");

        string input = ReadLine().ToLower();

        while (input != "д" && input != "н")
        {
            MoveToBlankPage();

            WriteLine("Ошибка ввода. Введите 'д' или 'н'.");
            Write("Вы уверены, что хотите выйти? (д/н): ");
            input = ReadLine().ToLower();
        }

        return input == "д";
    }
}
