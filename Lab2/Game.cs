using static System.Math;

namespace Lab2;

internal class Game
{
    private static Game _instance;

    public static Game Instance => _instance ??= new Game();

    private Game() { }

    public void Start()
    {
        WriteLine("Угадака\n");

        double a = 0.0d;
        double b = 0.0d;

        bool isCorrectUserInput = false;

        while (!isCorrectUserInput)
        {
            Write("Введите a: ");
            bool isCorrectA = double.TryParse(ReadLine(), out double inputA);

            Write("Введите b: ");
            bool isCorrectB = double.TryParse(ReadLine(), out double inputB);

            if (isCorrectA && isCorrectB)
            {
                isCorrectUserInput = true;

                a = inputA;
                b = inputB;
            }
            else
            {
                WriteLine("Неправильный ввод. Попробуйте снова.");
            }
        }

        GuessCorrectResult(a, b);
    }

    public void GuessCorrectResult(double a, double b)
    {
        Write("\nУгадай ответ (дробь с 2 знаками после запятой): ");

        double correctResult = Round(CalculateFormula(a, b), 2);

        if(!double.IsNaN(correctResult))
        {
            int answersCount = 0;

            while (answersCount < 3)
            {
                answersCount = UpdateAnswersCount(correctResult, answersCount);
            }

            if (answersCount == 3)
            {
                PrintGameResultMessage("Вы не угадали(( Тильт((");
            }
        }
    }

    private int UpdateAnswersCount(double correctResult, int answersCount)
    {
        if (double.TryParse(ReadLine(), out double userAnswer))
        {
            if (userAnswer != correctResult)
            {
                WriteLine("Неправильный ответ. Попробуйте снова.");
                answersCount++;
            }
            else
            {
                PrintGameResultMessage("Вы угадали! Шок!");
                answersCount = 4;
            }
        }
        else
        {
            WriteLine("Неправильный ввод. Попробуйте снова.");
            answersCount++;
        }

        return answersCount;
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
            ApplicationHelper.Instance.LogError(ex.Message);

            return double.NaN;
        }
    }

    private void PrintGameResultMessage(string resultMessage)
    {
        for (int i = 5 ; i > 0 ; i--)
        {
            Application.Instance.MoveToBlankPage();
            WriteLine($"{resultMessage} Возвращение в меню через {i} секунд...");
            Thread.Sleep(1000);
        }
    }
}
