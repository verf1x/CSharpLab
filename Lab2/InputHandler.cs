namespace Lab2;

public static class InputHandler
{
    public static bool TryParse<T>(string input, out T result)
    {
        try
        {
            result = (T)Convert.ChangeType(input, typeof(T));
            return true;
        }
        catch
        {
            result = default(T);
            return false;
        }
    }
    
    public static T GetInput<T>(string pattern, Func<T, bool> validate = null)
    {
        T result;
        bool isCorrectInput = false;
        
        do
        {
            Console.WriteLine($"Введите значение {pattern}:");
            
            if (TryParse(Console.ReadLine(), out result) && (validate is null || validate(result)))
                isCorrectInput = true;
            else
                SimpleLogger.Instance.LogIncorrectInput();
        } while (!isCorrectInput);
        
        return result;
    }

}