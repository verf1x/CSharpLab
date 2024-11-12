namespace CSLab.Modules;

/// <summary>
/// Piece generator interface
/// </summary>
internal interface IPieceGenerator
{
    /// <summary>
    /// Generate the next piece
    /// </summary>
    /// <returns></returns>
    Piece GetNextPiece();
}