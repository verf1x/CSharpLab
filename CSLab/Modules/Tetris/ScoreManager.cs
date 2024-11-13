namespace CSLab.Modules;

/// <summary>
/// Class that manages the score
/// </summary>
internal class ScoreManager : IScoreManager
{
    public int Score { get; private set; }

    public void AddScore(int linesCleared)
    {
        int points = linesCleared switch
        {
            1 => 40,
            2 => 100,
            3 => 300,
            4 => 1200,
            _ => 0,
        };
        Score += points;
    }

    public void Reset()
    {
        Score = 0;
    }
}