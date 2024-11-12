namespace CSLab.Modules;

/// <summary>
/// Array tools class
/// </summary>
internal class ArrayTools
{
    private readonly int _arrayLength;

    internal ArrayTools() : this(10) { }
    
    internal ArrayTools(int length)
    {
        _arrayLength = length;
    }
    
    private int[] FillNumbersArray(int length)
    {
        var result = new int[length];
        
        Random random = new();

        for (int i = 0; i < result.Length; i++)
            result[i] = random.Next(-10000, 10000);

        return result;
    }

    /// <summary>
    /// Returns filled with numbers array
    /// </summary>
    /// <returns></returns>
    internal int[] GetFilledWithNumbersArray()
    {
        return FillNumbersArray(_arrayLength);
    }
}
