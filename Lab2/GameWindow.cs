using System.Runtime.CompilerServices;
using static System.Console;
using static System.Math;

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
            Console.Clear();
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
        GameHelper.Instance.MoveToBlankPage();
        WriteLine("Угадака\n");

        Write("Введите a: ");
        double a = Convert.ToDouble(ReadLine());

        Write("Введите b: ");
        double b = Convert.ToDouble(ReadLine());

        Write("\nУгадай ответ (дробь с 2 знаками после запятой, разделитель: точка): ");

        double result = Round(CalculateFormula(a, b), 2);

        CompareUserAnswerWithResult(result);
    }

    private void CompareUserAnswerWithResult(double result)
    {
        bool isCorrect = false;
        int answersCount = 0;

        while (!isCorrect && answersCount < 3)
        {
            double userAnswer = Round(Convert.ToDouble(ReadLine()), 2);
            if (userAnswer == result)
            {
                isCorrect = true;
            }
            else
            {
                WriteLine("Неправильный ответ. Попробуйте снова.");
                answersCount++;
            }

            CheckResult(isCorrect, answersCount);
        }
    }

    private void CheckResult(bool isCorrect, int answersCount)
    {
        if (isCorrect)
        {
            PrintWinTitle();
        }
        else if (answersCount == 3)
        {
            Console.Clear();
            GameHelper.Instance.PrintTitle();
            WriteLine("Вы проиграли((");
            ReturnToMenu();
        }
    }

    private void PrintWinTitle()
    {
        for (int i = 5; i > 0; i--)
        {
            Console.Clear();
            GameHelper.Instance.PrintTitle();
            WriteLine($"Вы выиграли! Можно вернуться в меню через {i} секунд...");
            Thread.Sleep(1000);
        }

        ReturnToMenu();
    }

    private double CalculateFormula(double a, double b) //a = 2, b = 4 ~ 7.82
    {
        double numerator = Pow(Cos(PI), 7) + Sqrt(Log(Pow(b, 4)));
        double denumerator = Sin(PI / 2 + a) * Sin(PI / 2 + a);

        try
        {
            return numerator / denumerator;
        }
        catch (ArithmeticException ex)
        {
            ConsoleColor defaultColor = ForegroundColor;

            ForegroundColor = ConsoleColor.Red;

            WriteLine(ex.Message);

            ForegroundColor = defaultColor;

            return double.NaN;
        }
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
