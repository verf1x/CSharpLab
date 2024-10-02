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
                switch (choice)
                {
                    case 1:
                        PlayGame();
                        break;
                    case 2:
                        PrintAuthor();
                        break;
                    case 3:
                        isExit = ConfirmExit();
                        break;
                    default:
                        WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
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
