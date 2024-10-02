using static System.Console;

namespace Lab2;

internal class GameWindow
{
    private static GameWindow _instance;

    public static GameWindow Instance => _instance ??= new GameWindow();

    private GameWindow() { }

    public void Run()
    {
        bool isExit = false;

        while (!isExit)
        {
            Clear();
            GameHelper.Instance.PrintTitle();
            GameHelper.Instance.PrintMenu();

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

        GameHelper.Instance.MoveToBlankPage();
    }

    private void PlayGame()
    {
        //TODO: Реализовать игру

        GameHelper.Instance.MoveToBlankPage();
        WriteLine("Крутая математичсекая игра\n");

        ReturnToMenu();
    }

    private void ReturnToMenu()
    {
        WriteLine("Нажмите любую клавишу для возврата в меню...");
        ReadKey();
    }

    private void PrintAuthor()
    {
        GameHelper.Instance.MoveToBlankPage();
        WriteLine("Автор\tКупцов Никита Александрович\tГруппа\t6102-090301D\n");
        ReturnToMenu();
    }

    private bool ConfirmExit()
    {
        GameHelper.Instance.MoveToBlankPage();

        WriteLine("Вы уверены, что хотите выйти? (д/н): ");

        string input = ReadLine().ToLower();

        while (input != "д" && input != "н")
        {
            GameHelper.Instance.MoveToBlankPage();

            WriteLine("Ошибка ввода. Введите 'д' или 'н'.");
            Write("Вы уверены, что хотите выйти? (д/н): ");
            input = ReadLine().ToLower();
        }

        return input == "д";
    }
}
