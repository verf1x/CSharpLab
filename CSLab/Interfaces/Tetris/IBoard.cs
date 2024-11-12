namespace CSLab.Modules;

/// <summary>
/// Game board interface
/// </summary>
internal interface IBoard
{
    int Width { get; }
    int Height { get; }
    
    /// <summary>
    /// Checks if the piece can be placed at the given position
    /// </summary>
    /// <returns>true - if can be placed, false - if can't</returns>
    bool IsPositionValid(Piece piece, int x, int y, int rotation);
    
    /// <summary>
    /// Place the piece on the board by x and y coords
    /// </summary>
    void PlacePiece(Piece piece, int x, int y, int rotation);
    
    /// <summary>
    /// Clear completed lines and return the number of cleared lines
    /// </summary>
    /// <returns></returns>
    int ClearCompletedLines();
    
    /// <summary>
    /// Returns the current state of the board
    /// </summary>
    /// <returns></returns>
    char[,] GetBoardState();
    
    /// <summary>
    /// Reset the board
    /// </summary>
    void Reset();
}