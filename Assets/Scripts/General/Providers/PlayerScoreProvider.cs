using UnityEngine;

public class PlayerScoreProvider : MonoBehaviour, IScoreProvider
{
    private const string HighScoreKey = "HighScore";

    private int _score;
    public int Score 
    { 
        get
        {
            return _score > 0 ? _score : _score = 0;
        }

        protected set
        {
            _score = value;
        }
    }

    private int _highScore;
    public int HighScore 
    {
        get
        {
            return _highScore > 0 ? _highScore : _highScore = PlayerPrefs.GetInt(HighScoreKey);
        }

        protected set
        {
            _highScore = value;
        }
    } 

    public void Init()
    {
        Score = 0;
        
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            HighScore = PlayerPrefs.GetInt(HighScoreKey);

            return;
        }

        HighScore = 0;

        PlayerPrefs.SetInt(HighScoreKey, 0);
    }

    public void AddScore(int amt)
    {
        if (amt < 0)
        {
            Debug.LogError("SpaceInvadersScoreProvider::AddScore() => Score cannot be less than 0!");

            return;
        }

        Score += amt;
    }

    public void SaveHighScore()
    {
        if (Score > HighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Score);

            HighScore = Score;
        }
    }
}
