using CSLab.Interfaces;

namespace CSLab.Modules;

/// <summary>
/// Tetris game class
/// </summary>
internal class Tetris
    {
        private readonly IBoard _board;
        private readonly IPieceGenerator _pieceGenerator;
        private readonly IInputHandler _inputHandler;
        private readonly IRenderer _renderer;
        private readonly IScoreManager _scoreManager;
        private readonly ILogger _logger;

        private Piece _currentPiece;
        private Piece _holdPiece;
        private Piece _nextPiece;
        private int _currentX;
        private int _currentY;
        private int _currentRotation;
        private bool _isGameOver;
        private int _dropTimer;
        private int _dropInterval;

        public Tetris(
            IBoard board,
            IPieceGenerator pieceGenerator,
            IInputHandler inputHandler,
            IRenderer renderer,
            IScoreManager scoreManager)
        {
            _board = board;
            _pieceGenerator = pieceGenerator;
            _inputHandler = inputHandler;
            _renderer = renderer;
            _scoreManager = scoreManager;

            _dropInterval = 20;
        }

        /// <summary>
        /// Runs the Tetris
        /// </summary>
        internal void Run()
        {
            RestartGame();
            Console.Clear();
            InitializeGame();
            Task inputTask = Task.Run(() => HandleInput());

            while (!_isGameOver)
            {
                UpdateGame();
                _renderer.Render(_board.GetBoardState(), _currentPiece, _currentX, _currentY, _holdPiece, _nextPiece, _scoreManager.Score, _currentRotation);
                Thread.Sleep(20);
            }
            
            Console.CursorVisible = true;
            GameOver();
        }

        private void InitializeGame()
        {
            _currentPiece = _pieceGenerator.GetNextPiece();
            _nextPiece = _pieceGenerator.GetNextPiece();
            _currentX = _board.Width / 2;
            _currentY = 0;
            _currentRotation = 0;
            _isGameOver = false;
        }

        private void UpdateGame()
        {
            _dropTimer++;
            
            if (_dropTimer >= _dropInterval)
            {
                MovePieceDown();
                _dropTimer = 0;
            }
        }

        private void MovePieceDown()
        {
            if (_board.IsPositionValid(_currentPiece, _currentX, _currentY + 1, _currentRotation))
            {
                _currentY++;
            }
            else
            {
                LockPiece();
                ClearLines();
                SpawnNewPiece();
            }
        }

        private void LockPiece()
        {
            _board.PlacePiece(_currentPiece, _currentX, _currentY, _currentRotation);
        }

        private void ClearLines()
        {
            int linesCleared = _board.ClearCompletedLines();
            _scoreManager.AddScore(linesCleared);
        }

        private void SpawnNewPiece()
        {
            _currentPiece = _nextPiece;
            _nextPiece = _pieceGenerator.GetNextPiece();
            _currentX = _board.Width / 2;
            _currentY = 0;
            _currentRotation = 0;

            if (!_board.IsPositionValid(_currentPiece, _currentX, _currentY, _currentRotation))
                _isGameOver = true;
        }

        private void HandleInput()
        {
            while (!_isGameOver)
            {
                ConsoleKey? key = _inputHandler.GetInput();
                
                if (key.HasValue)
                    ProcessInput(key.Value);
                
                Thread.Sleep(10);
            }
        }

        private void ProcessInput(ConsoleKey key)
        {
            Action keyAction = key switch
            {
                ConsoleKey.LeftArrow or ConsoleKey.A => MovePieceLeft,
                ConsoleKey.RightArrow or ConsoleKey.D => MovePieceRight,
                ConsoleKey.UpArrow or ConsoleKey.W => RotatePiece,
                ConsoleKey.DownArrow or ConsoleKey.S => MovePieceDown,
                ConsoleKey.Spacebar => HardDropPiece,
                ConsoleKey.Enter => HoldCurrentPiece,
                ConsoleKey.R => RestartGame,
                ConsoleKey.Escape => ExitGame,
                _ => () => { }
            };
            
            keyAction?.Invoke();
        }

        private void MovePieceLeft()
        {
            if (_board.IsPositionValid(_currentPiece, _currentX - 1, _currentY, _currentRotation))
                _currentX--;
        }

        private void MovePieceRight()
        {
            if (_board.IsPositionValid(_currentPiece, _currentX + 1, _currentY, _currentRotation))
                _currentX++;
        }

        private void RotatePiece()
        {
            int newRotation = (_currentRotation + 1) % 4;
            
            if (_board.IsPositionValid(_currentPiece, _currentX, _currentY, newRotation))
                _currentRotation = newRotation;
        }

        private void HardDropPiece()
        {
            while (_board.IsPositionValid(_currentPiece, _currentX, _currentY + 1, _currentRotation))
                _currentY++;
            
            LockPiece();
            ClearLines();
            SpawnNewPiece();
        }

        private void HoldCurrentPiece()
        {
            if (_holdPiece == null)
            {
                _holdPiece = _currentPiece;
                SpawnNewPiece();
            }
            else
            {
                (_currentPiece, _holdPiece) = (_holdPiece, _currentPiece);
                _currentX = _board.Width / 2;
                _currentY = 0;
                _currentRotation = 0;
            }
        }

        private void RestartGame()
        {
            _board.Reset();
            _scoreManager.Reset();
            InitializeGame();
        }

        private void ExitGame()
        {
            _isGameOver = true;
        }
        
        private void GameOver()
        {
            Console.Clear();
            ApplicationHelper.PrintTitle();

            ForegroundColor = ConsoleColor.Red;
            
            bool restart = InputHandler.GetInputByPattern<string>("Игра окончена. Хотите начать заново? (д/н): ",
                input => input == "д" || input == "н") == "д";
            
            if (restart)
                Run();
        }
    }