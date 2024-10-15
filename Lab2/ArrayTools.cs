namespace Lab2;

using System.Diagnostics;

internal static class ArrayTools
{
    public static T[] CreateArray<T>(int length)
    {
        return new T[length];
    }

    public static void FillNumbersArray(int[] array)
    {
        Random random = new();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-10000, 10000);
        }
    }



    public static bool TryGetArray(out int[] array)
    {
        Application.Instance.MoveToBlankPage();

        WriteLine("Введите размер массива: ");

        if (int.TryParse(ReadLine(), out int length) && length > 0)
        {
            array = CreateArray<int>(length);

            return true;
        }
        else
        {
            ApplicationHelper.Instance.LogIvalidInput();
            array = Array.Empty<int>();

            return false;
        }
    }

    public static void SetupSortingBenchmark(int[] array)
    {
        PrintArrayAndSort(array, Sorter.GetBubbleSortTookedTicks, "Сортировка пузырьком заняла {0} тиков");
        PrintArrayAndSort(array, Sorter.GetIntersectionSortTookedTicks, "Сортировка вставками заняла {0} тиков");

        WriteLine("Нажмите любую клавишу для возврата в меню...");
        ReadKey();
    }

    public static void PrintArrayAndSort(int[] array, Func<int[], long> sortFunc, string message)
    {
        int[] arrayToSort = new int[array.Length];
        Array.Copy(array, arrayToSort, arrayToSort.Length);

        PrintArray(arrayToSort, "Исходный массив");
        long elapsedTicks = sortFunc(arrayToSort);

        WriteLine(string.Format(message, elapsedTicks));

        PrintArray(arrayToSort, "Отсортированный массив");

        WriteLine();
    }

    public static void PrintArray(int[] array, string message)
    {
        if(array.Length > 10)
        {
            WriteLine("Массив не может быть выведен на экран, так как его длина больше 10.");
        }
        else
        {
            Write($"{message}: [");

            for (int i = 0; i < array.Length; i++)
            {
                Write(" " + array[i] + " ");
            }

            Write("]\n");
        }
    }
}
