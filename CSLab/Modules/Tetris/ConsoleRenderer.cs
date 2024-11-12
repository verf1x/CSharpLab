namespace CSLab.Modules;

/// <summary>
/// Implement this interface to render the game
/// </summary>
internal class ConsoleRenderer : IRenderer
    {
        void IRenderer.Render(char[,] boardState, Piece currentPiece, int currentX, int currentY, Piece holdPiece, Piece nextPiece, int score, int currentRotation)
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            
            char[,] view = GetView(boardState, currentPiece, currentX, currentY, currentRotation);
            RenderBoard(view);
            RenderSidePanel(holdPiece, nextPiece, score);
        }

        private char[,] GetView(char[,] boardState, Piece currentPiece, int currentX, int currentY, int currentRotation)
        {
            int height = boardState.GetLength(0);
            int width = boardState.GetLength(1);
            char[,] view = new char[height, width];
            Array.Copy(boardState, view, boardState.Length);

            var blocks = currentPiece.GetBlocks(currentRotation);
            foreach (var block in blocks)
            {
                int x = currentX + block.X;
                int y = currentY + block.Y;
                if (y >= 0 && y < height && x >= 0 && x < width)
                {
                    view[y, x] = currentPiece.Symbol;
                }
            }
            return view;
        }

        private void RenderBoard(char[,] view)
        {
            int height = view.GetLength(0);
            int width = view.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                Console.Write("|");
                for (int x = 0; x < width; x++)
                {
                    char cell = view[y, x];
                    SetCellColor(cell);
                    Console.Write(cell == '-' ? ' ' : cell);
                    Console.ResetColor();
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(new string('-', width + 2));
        }

        private void RenderSidePanel(Piece holdPiece, Piece nextPiece, int score)
        {
            Console.WriteLine($"Score: {score}");
            Console.WriteLine("Hold:");
            RenderPiece(holdPiece);
            Console.WriteLine("Next:");
            RenderPiece(nextPiece);
        }

        private void RenderPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.WriteLine("[Empty]");
                return;
            }

            var blocks = piece.GetBlocks(0);
            int gridSize = 4;
            char[,] grid = new char[gridSize, gridSize];

            for (int y = 0; y < gridSize; y++)
                for (int x = 0; x < gridSize; x++)
                    grid[y, x] = ' ';

            foreach (var block in blocks)
            {
                grid[block.Y, block.X] = piece.Symbol;
            }

            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    char cell = grid[y, x];
                    SetCellColor(cell);
                    Console.Write(cell);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        private void SetCellColor(char cell)
        {
            switch (cell)
            {
                case 'O':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 'I':
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 'T':
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 'S':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'Z':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 'J':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 'L':
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
    }