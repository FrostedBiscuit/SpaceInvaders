public interface IScoreProvider
{
    int Score { get; }
    int HighScore { get; }

    void Init();
    void AddScore(int amt);
    void SaveHighScore();
}