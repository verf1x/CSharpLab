using CSLab.Interfaces;

namespace CSLab.Modules;

internal class Menu : IMenuService
{
    private readonly ApplicationHelper _applicationHelper;
    private readonly ILogger _logger;
    private readonly InputHandler _inputHandler;
    private readonly Dictionary<int, string> _menuItems;

    public Menu(ApplicationHelper applicationHelper, ILogger logger, InputHandler inputHandler)
    {
        _applicationHelper = applicationHelper;
        _logger = logger;
        _inputHandler = inputHandler;
        _menuItems = [];
        InitializeMenu();
    }

    private void InitializeMenu()
    {
        _menuItems.Add(1, "Угадака");
        _menuItems.Add(2, "Об авторе");
        _menuItems.Add(3, "Сортировка массива");
        _menuItems.Add(4, "Выход\n");
    }

    void IMenuService.Display()
    {
        Console.Clear();
        _applicationHelper.PrintTitle();

        foreach (var item in _menuItems)
            WriteLine($"{item.Key}. {item.Value}");
    }

    int IMenuService.GetUserChoice()
    {
        int choice = _inputHandler.GetInputByPattern<int>("Выберите пункт меню: ",
            input => input >= 1 && input <= _menuItems.Count);

        return choice;
    }

    bool IMenuService.ConfirmExit()
    {
        Console.Clear();
        _applicationHelper.PrintTitle();

        return _inputHandler.GetInputByPattern<string>("Вы уверены, что хотите выйти? (д/н): ",
            input => input == "д" || input == "н") == "д";
        
    }    
}