namespace CSLab.Modules;

internal class ArrayTools
{
    private readonly InputHandler _inputHandler;
    
    public ArrayTools(InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }
    
    private int[] FillNumbersArray(int length)
    {
        var result = new int[length];
        
        Random random = new();

        for (int i = 0; i < result.Length; i++)
            result[i] = random.Next(-10000, 10000);

        return result;
    }

    internal int[] GetFilledWithNumbersArray()
    {
        int length = _inputHandler.GetInputByPattern<int>("Введите размер массива: ", input => input > 0);

        return FillNumbersArray(length);
    }
}
