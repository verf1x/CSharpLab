using CSLab.Interfaces;

namespace CSLab.Modules;

/// <summary>
/// Class that represents a menu
/// </summary>
internal class Menu
{
    private readonly ILogger _logger;
    private readonly Dictionary<int, string> _menuItems;

    public Menu(ILogger logger)
    {
        _logger = logger;
        _menuItems = [];
        InitializeMenu();
    }

    private void InitializeMenu()
    {
        _menuItems.Add(1, "Угадака");
        _menuItems.Add(2, "Об авторе");
        _menuItems.Add(3, "Сортировка массива");
        _menuItems.Add(4, "Сыграть в тетрис");
        _menuItems.Add(5, "Выход\n");
    }

    /// <summary>
    /// Display the menu
    /// </summary>
    internal void Display()
    {
        Console.Clear();
        ApplicationHelper.PrintTitle();

        foreach (var item in _menuItems)
            WriteLine($"{item.Key}. {item.Value}");
    }

    /// <summary>
    /// Get user choice from the menu
    /// </summary>
    /// <returns></returns>
    internal int GetUserChoice()
    {
        int choice = InputHandler.GetInputByPattern<int>("Выберите пункт меню: ",
            input => input >= 1 && input <= _menuItems.Count);

        return choice;
    }

    /// <summary>
    /// Ask user to confirm exit
    /// </summary>
    /// <returns></returns>
    internal bool ConfirmExit()
    {
        Console.Clear();
        ApplicationHelper.PrintTitle();

        return InputHandler.GetInputByPattern<string>("Вы уверены, что хотите выйти? (д/н): ",
            input => input == "д" || input == "н") == "д";
        
    }    
}