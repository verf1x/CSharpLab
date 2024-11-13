using System.Diagnostics;

namespace CSLab.Modules;

/// <summary>
/// Class to benchmark sorting algorithms
/// </summary>
internal class SortsBenchmark<T> where T : IComparable<T>
{
    private readonly Stopwatch _stopwatch = new();
    private T[] _array1;
    private T[] _array2;
    
    /// <summary>
    /// Method to run the benchmark
    /// </summary>
    /// <param name="arr"></param>
    internal void Run(T[] arr)
    {
        Init(arr);
        
        StartSorting(_array1, GetBubbleSortTookedMs, "Сортировка пузырьком заняла {0} ms");
        StartSorting(_array2, GetIntersectionSortTookedMs, "Сортировка вставками заняла {0} ms");
    }

    private void Init(T[] array)
    {
        _array1 = new T [array.Length];
        _array2 = new T [array.Length];
        
        Array.Copy(array, 0, _array1, 0, array.Length);
        Array.Copy(array, 0, _array2, 0, array.Length);
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
                Write(" " + array[i] + " ");

            Write("]\n");
        }
    }
    
    private double GetBubbleSortTookedMs(T[] array)
    {
        _stopwatch.Start();

        int n = array.Length;

        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (array[j].CompareTo(array[j + 1]) > 0)
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);

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