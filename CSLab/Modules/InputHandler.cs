using CSLab.Interfaces;

namespace CSLab.Modules;

internal class InputHandler
{
    private readonly ILogger _logger;
    
    public InputHandler(ILogger logger)
    {
        _logger = logger;
    }
    
    private bool TryParse<T>(string input, out T result)
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
    
    internal T GetInputByPattern<T>(string pattern, Func<T, bool> validate = null)
    {
        T result;
        bool isCorrectInput = false;
        
        do
        {
            Write($"{pattern}");
            
            if (TryParse(ReadLine(), out result) && (validate is null || validate(result)))
                isCorrectInput = true;
            else
                _logger.LogIncorrectInput();
        } while (!isCorrectInput);
        
        return result;
    }

}