﻿using CSLab.Interfaces;
using static System.Math;

namespace CSLab.Modules;

internal class MathGame
{
    private readonly InputHandler _inputHandler;
    private readonly ILogger _logger;

    public MathGame(InputHandler inputHandler, ILogger logger)
    {
        _inputHandler = inputHandler;
        _logger = logger;
    }

    internal void Start()
    {
        WriteLine("Угадака\n");

        double a = _inputHandler.GetInputByPattern<double>("Введите a ≠ π/2 + k, k ∊ ℤ: ",
            input => input % (PI / 2) != 0);
        double b = _inputHandler.GetInputByPattern<double>("Введите b ≠ 0: ",
            input => input != 0);

        GuessCorrectResult(a, b);
    }

    private void GuessCorrectResult(double a, double b)
    {
        Write("\nУгадай ответ (дробь с 2 знаками после запятой, разделитель запятая): ");

        double correctResult = Round(CalculateFormula(a, b), 2);

        if (!double.IsNaN(correctResult))
        {
            int answersCount = 0;

            while (answersCount < 3)
                answersCount = UpdateAnswersCount(correctResult, answersCount);

            if (answersCount == 3)
                PrintGameResultMessage("Вы не угадали(( Тильт((");
        }
        else
        {
            _logger.LogIncorrectInput();
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
           _logger.LogIncorrectInput();
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
            Write($"\r{resultMessage} Возвращение в меню через {i} секунд...\r");
            Thread.Sleep(1000);
        }
    }
}