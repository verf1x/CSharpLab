﻿namespace Lab2;

using static System.Math;

internal class MathGame
{
    private static MathGame _instance;
    public static MathGame Instance => _instance ??= new MathGame();

    private MathGame() { }

    public void Start()
    {
        WriteLine("Угадака\n");

        double a = InputHandler.GetInput<double>("Введите a ≠ π/2 + k, k ∊ ℤ: ",
            input => input % (PI / 2) != 0);
        double b = InputHandler.GetInput<double>("Введите b ≠ 0: ",
            input => input != 0);

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
            SimpleLogger.Instance.LogIncorrectInput();
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
            SimpleLogger.Instance.LogIncorrectInput();
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