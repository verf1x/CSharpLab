namespace CSLab.Modules;

/// <summary>
/// Game board class
/// </summary>
internal class Board : IBoard
    {
        private readonly char[,] _grid;
        private const char EmptyCell = '-';

        public int Width { get; } = 10;
        public int Height { get; } = 10;

        public Board()
        {
            _grid = new char[Height, Width];
            ((IBoard)this).Reset();
        }

        bool IBoard.IsPositionValid(Piece piece, int x, int y, int rotation)
        {
            var blocks = piece.GetBlocks(rotation);
            foreach (var block in blocks)
            {
                int boardX = x + block.X;
                int boardY = y + block.Y;

                if (IsOutOfBounds(boardX, boardY) || IsCellOccupied(boardX, boardY))
                {
                    return false;
                }
            }
            return true;
        }

        void IBoard.PlacePiece(Piece piece, int x, int y, int rotation)
        {
            var blocks = piece.GetBlocks(rotation);
            foreach (var block in blocks)
            {
                int boardX = x + block.X;
                int boardY = y + block.Y;
                _grid[boardY, boardX] = piece.Symbol;
            }
        }

        int IBoard.ClearCompletedLines()
        {
            int linesCleared = 0;
            for (int y = 0; y < Height; y++)
            {
                if (IsLineComplete(y))
                {
                    RemoveLine(y);
                    linesCleared++;
                }
            }
            return linesCleared;
        }

        char[,] IBoard.GetBoardState()
        {
            var stateCopy = new char[Height, Width];
            Array.Copy(_grid, stateCopy, _grid.Length);
            return stateCopy;
        }

        void IBoard.Reset()
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    _grid[y, x] = EmptyCell;
        }

        private bool IsOutOfBounds(int x, int y)
        {
            return x < 0 || x >= Width || y < 0 || y >= Height;
        }

        private bool IsCellOccupied(int x, int y)
        {
            return _grid[y, x] != EmptyCell;
        }

        private bool IsLineComplete(int y)
        {
            for (int x = 0; x < Width; x++)
            {
                if (_grid[y, x] == EmptyCell)
                    return false;
            }
            return true;
        }

        private void RemoveLine(int y)
        {
            for (int row = y; row > 0; row--)
            {
                for (int col = 0; col < Width; col++)
                {
                    _grid[row, col] = _grid[row - 1, col];
                }
            }
            for (int col = 0; col < Width; col++)
            {
                _grid[0, col] = EmptyCell;
            }
        }
    }