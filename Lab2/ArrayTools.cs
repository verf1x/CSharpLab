namespace Lab2;

internal static class ArrayTools<T>
{
    public static void FillNumbersArray(int[] array)
    {
        Random random = new();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-10000, 10000);
        }
    }

    public static T[] GetArray()
    {
        Application.Instance.MoveToBlankPage();

        WriteLine("Введите размер массива: ");

        if (int.TryParse(ReadLine(), out int length) && length > 0)
        {
            return new T[length];
        }
        else
        {
            SimpleLogger.Instance.LogIncorrectInput();
            return Array.Empty<T>();
        }
    }
}
