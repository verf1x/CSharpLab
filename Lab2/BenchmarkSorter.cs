using System.Diagnostics;

namespace Lab2;

internal static class BenchmarkSorter
{
    private static readonly Stopwatch _stopwatch = new();

    public static double GetBubbleSortTookedTicks(int[] array)
    {
        _stopwatch.Start();

        int n = array.Length;

        for (int i = 0 ; i < n - 1 ; i++)
        {
            for (int j = 0 ; j < n - i - 1 ; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }

        _stopwatch.Stop();

        return _stopwatch.Elapsed.TotalNanoseconds;
    }

    public static double GetIntersectionSortTookedTicks(int[] array)
    {
        _stopwatch.Start();

        for (int i = 1 ; i < array.Length ; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }

        _stopwatch.Stop();

        return _stopwatch.Elapsed.TotalNanoseconds;
    }
}