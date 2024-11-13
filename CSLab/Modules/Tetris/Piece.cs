namespace CSLab.Modules;

/// <summary>
/// Represents a tetromino piece in the game
/// </summary>
internal class Piece
{
    public char Symbol { get; }
    public ConsoleColor Color { get; }
    private readonly int[,,] _rotations;

    public Piece(char symbol, int[,,] rotations, ConsoleColor color)
    {
        Symbol = symbol;
        _rotations = rotations;
        Color = color;
    }

    /// <summary>
    /// Returns the blocks of the piece for the given rotation
    /// </summary>
    /// <param name="rotation">Rotation of the piece</param>
    /// <returns>List of blocks in given rotation</returns>
    internal List<Block> GetBlocks(int rotation)
    {
        var blocks = new List<Block>();
        int[,] shape = GetRotation(rotation);
        
        for (int i = 0; i < shape.GetLength(0); i++)
            blocks.Add(new Block(shape[i, 0], shape[i, 1]));
        
        return blocks;
    }

    private int[,] GetRotation(int rotation)
    {
        int rotationIndex = rotation % _rotations.GetLength(0);
        int[,] rotationShape = new int[_rotations.GetLength(1), 2];
        
        for (int i = 0; i < _rotations.GetLength(1); i++)
        {
            rotationShape[i, 0] = _rotations[rotationIndex, i, 0];
            rotationShape[i, 1] = _rotations[rotationIndex, i, 1];
        }
        return rotationShape;
    }
}