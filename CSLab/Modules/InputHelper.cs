using CSLab.Interfaces;

namespace CSLab.Modules;

/// <summary>
/// Input handler class
/// </summary>
internal static class InputHandler
{
    private static bool TryParse<T>(string input, out T result)
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
    
    /// <summary>
    /// Method to get input by pattern
    /// </summary>
    /// <param name="pattern">pattern for user</param>
    /// <param name="validate">checks if input matching pattern</param>
    /// <returns>value</returns>
    internal static T GetInputByPattern<T>(string pattern, Func<T, bool> validate = null)
    {
        T result;
        bool isCorrectInput = false;
        
        do
        {
            Write($"{pattern}");
            
            if (TryParse(ReadLine(), out result) && (validate is null || validate(result)))
                isCorrectInput = true;
            else
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                ForegroundColor = ConsoleColor.Gray;
            }
        } while (!isCorrectInput);
        
        return result;
    }

}