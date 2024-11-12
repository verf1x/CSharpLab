namespace CSLab.Modules;

/// <summary>
/// Represent a block in the game
/// </summary>
internal class Block
{
    public int X { get; }
    public int Y { get; }

    public Block(int x, int y)
    {
        X = x;
        Y = y;
    }
}