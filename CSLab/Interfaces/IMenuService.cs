namespace CSLab.Interfaces;

internal interface IMenuService
{ 
    void Display();
    int GetUserChoice();
    bool ConfirmExit();
}