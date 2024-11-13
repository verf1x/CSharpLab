namespace CSLab.Modules;

/// <summary>
/// Represent a block in the game
/// </summary>
internal class Block(int x, int y)
{
    /// <summary>
    /// X property
    /// </summary>
    public int X { get; } = x;

    /// <summary>
    /// Y property
    /// </summary>
    public int Y { get; } = y;
}