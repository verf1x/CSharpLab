namespace Lab2;

using System.Diagnostics;

internal class SortingsBenchmark<T> where T : IComparable<T>
{
    private readonly Stopwatch _stopwatch = new();
    private readonly T[] _array1;
    private readonly T[] _array2;

    public SortingsBenchmark(T[] array)
    {
        _array1 = new T [array.Length];
        _array2 = new T [array.Length];
        
        Array.Copy(array, 0, _array1, 0, array.Length);
        Array.Copy(array, 0, _array2, 0, array.Length);
    }
    
    public void Run()
    {
        StartSorting(_array1, GetBubbleSortTookedMs, "Сортировка пузырьком заняла {0} ms");
        StartSorting(_array2, GetIntersectionSortTookedMs, "Сортировка вставками заняла {0} ms");
        
        Application.Instance.ReturnToMenuByPressingKey();
    }
    
    private void StartSorting(T[] array, Func<T[], double> sortFunc, string message)
    {
        PrintArray(array, "Исходный массив");
        double elapsedMs = sortFunc(array);

        WriteLine(string.Format(message, elapsedMs));

        PrintArray(array, "Отсортированный массив");

        WriteLine();
    }

    private void PrintArray(T[] array, string message)
    {
        if(array.Length > 10)
        {
            WriteLine("НЕЕЕЕЕЕЕЕЕЕ!!!!لا أستطيع إخراج أكثر من 10 عناصر ПОТОМУ ЧТО МЕНЯ УЩЕМИЛО ТЗ(((((");
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
    
    private double GetBubbleSortTookedMs(T[] array)
    {
        _stopwatch.Start();

        int n = array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }

        _stopwatch.Stop();

        return _stopwatch.Elapsed.TotalMilliseconds;
    }

    private double GetIntersectionSortTookedMs(T[] array)
    {
        _stopwatch.Start();

        for (int i = 1; i < array.Length; i++)
        {
            T key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j].CompareTo(key) > 1)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }

        _stopwatch.Stop();

        return _stopwatch.Elapsed.TotalMilliseconds;
    }
}