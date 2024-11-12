namespace CSLab.Modules;

/// <summary>
/// Game renderer interface
/// </summary>
internal interface IRenderer
{
    /// <summary>
    /// Render the game
    /// </summary>
    /// <param name="boardState">Board state</param>
    /// <param name="currentPiece"> Current piece</param>
    /// <param name="currentX">Current X</param>
    /// <param name="currentY">Current Y</param>
    /// <param name="holdPiece">Hold Piece</param>
    /// <param name="nextPiece">Next Piece</param>
    /// <param name="score">Current Score</param>
    /// <param name="currentRotation"> Current piece rotation</param>
    void Render(char[,] boardState, Piece currentPiece, int currentX, int currentY, Piece holdPiece, Piece nextPiece, int score, int currentRotation);
}