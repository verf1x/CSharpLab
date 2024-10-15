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
            Write("Введите a ≠ 𝞹/2 + 𝞹k, k ∊ ℤ: "); //invalid input example: 1.5707963267948966
            bool isCorrectA = double.TryParse(ReadLine(), out double inputA);

            Write("Введите b ≠ 0: ");
            bool isCorrectB = double.TryParse(ReadLine(), out double inputB);

            if (isCorrectA && isCorrectB && inputA % (1 / 2 * PI) != 0 && inputB != 0)
            {
                isCorrectUserInput = true;

                a = inputA;
                b = inputB;
            }
            else
            {
                ApplicationHelper.Instance.LogIncorrectInput();
            }
        }

        GuessCorrectResult(a, b);
    }

    public void GuessCorrectResult(double a, double b)
    {
        Write("\nУгадай ответ (дробь с 2 знаками после запятой, разделитель запятая): ");

        double correctResult = Round(CalculateFormula(a, b), 2);

        if (!double.IsNaN(correctResult))
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
        else
        {
            ApplicationHelper.Instance.LogIncorrectInput();
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
            ApplicationHelper.Instance.LogIvalidInput();
            answersCount++;
        }

        return answersCount;
    }

    private double CalculateFormula(double a, double b) //a = 2, b = 4 ~ 7,82
    {
        double numerator = Pow(Cos(PI), 7) + Sqrt(Log(Pow(b, 4)));
        double denumerator = Pow(Sin(PI / 2 + a), 2);

        return numerator / denumerator;
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
