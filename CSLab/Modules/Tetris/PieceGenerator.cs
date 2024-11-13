namespace CSLab.Modules;

/// <summary>
/// Implementation of the piece generator
/// </summary>
internal class PieceGenerator : IPieceGenerator
{
    private readonly List<Piece> _pieces;
    private Queue<Piece> _bag;
    private readonly Random _random;

    public PieceGenerator()
    {
        _pieces = InitializePieces();
        _random = new Random();
        _bag = GenerateShuffledBag();
    }

    public Piece GetNextPiece()
    {
        if (_bag.Count == 0)
            _bag = GenerateShuffledBag();
        
        return _bag.Dequeue();
    }

    private Queue<Piece> GenerateShuffledBag()
    {
        var shuffledPieces = new List<Piece>(_pieces);
        int n = shuffledPieces.Count;
        while (n > 1)
        {
            n--;
            int k = _random.Next(n + 1);
            (shuffledPieces[k], shuffledPieces[n]) = (shuffledPieces[n], shuffledPieces[k]);
        }
        return new Queue<Piece>(shuffledPieces);
    }

    private List<Piece> InitializePieces()
    {
        return new List<Piece>
        {
            new Piece('O', TetrominoShapes.OShape, ConsoleColor.Yellow),
            new Piece('I', TetrominoShapes.IShape, ConsoleColor.Cyan),
            new Piece('T', TetrominoShapes.TShape, ConsoleColor.Magenta),
            new Piece('S', TetrominoShapes.SShape, ConsoleColor.Green),
            new Piece('Z', TetrominoShapes.ZShape, ConsoleColor.Red),
            new Piece('J', TetrominoShapes.JShape, ConsoleColor.Blue),
            new Piece('L', TetrominoShapes.LShape, ConsoleColor.DarkYellow)
        };
    }
}