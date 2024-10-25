namespace Lab2
{
    internal class Menu
    {
        private readonly Dictionary<int, (Action action, string name)> _menuItems;

        public Menu()
        {
            _menuItems = new Dictionary<int, (Action action, string name)>();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            _menuItems.Add(1, (MathGame.Instance.Start, "Угадака"));
            _menuItems.Add(2, (PrintAuthor, "Об авторе"));
            _menuItems.Add(3, (SortArray, "Сортировка массива"));
            _menuItems.Add(4, (() => Application.Instance.Exit(), "Выход\n"));
        }

        public void ShowMenu()
        {
            Application.Instance.MoveToBlankPage();

            foreach (var item in _menuItems)
                Console.WriteLine($"{item.Key}. {item.Value.name}");
        }

        public void HandleUserChoice()
        {
            if (int.TryParse(ReadLine(), out int choice))
            {
                if (_menuItems.ContainsKey(choice))
                    _menuItems[choice].action?.Invoke();
                else
                    SimpleLogger.Instance.LogIncorrectInput();
            }
        }

        private void PrintAuthor()
        {
            Application.Instance.MoveToBlankPage();
            Console.WriteLine("Автор\tКупцов Никита Александрович\tГруппа\t6102-090301D\n");
            Application.Instance.ReturnToMenuByPressingKey();
        }

        private void SortArray()
        {
            bool isCorrectInput = false;

            while (!isCorrectInput)
            {
                int[] arrayToSort = ArrayTools<int>.GetArray();

                if (arrayToSort.Length > 0)
                {
                    isCorrectInput = true;

                    ArrayTools<int>.FillNumbersArray(arrayToSort);
                    new SortingsBenchmark<int>(arrayToSort).Run();
                }
            }
        }
    }
}