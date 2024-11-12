namespace CSLab.Modules;

internal interface IScoreManager
{
    int Score { get; }
    
    /// <summary>
    /// Adding score based on the number of lines cleared
    /// </summary>
    /// <param name="linesCleared"></param>
    void AddScore(int linesCleared);
    
    /// <summary>
    /// Reset the score
    /// </summary>
    void Reset();
}