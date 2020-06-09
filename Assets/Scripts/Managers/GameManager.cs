using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singelton
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("GameManager::Awake() => More than 1 GameManager in the scene!!!");

            return;
        }

        instance = this;
    }
    #endregion

    private const string HighScoreKey = "HighScore";

    private const float GridYStart = 6.5f;

    public int Score { get; protected set; }
    public int HighScore { get; protected set; }

    [SerializeField]
    private GameObject EnemyGridPrefab;
    [SerializeField]
    private GameObject DefeatPanel;

    private void Start()
    {
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            HighScore = PlayerPrefs.GetInt(HighScoreKey);
        }
        else
        {
            HighScore = 0;

            PlayerPrefs.SetInt(HighScoreKey, 0);
        }
    }

    public void PlayerWon()
    {
        Invoke("RespawnGrid", 1f);
    }

    public void PlayerLost()
    {
        // Probably display a "try again" panel here

        DefeatPanel.SetActive(true);

        if (Score > HighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Score);
        }
    }

    public void ReloadLevel()
    {
        PlayerHealth.Lives = 3;

        SceneManager.LoadScene("Main");
    }

    public void AddScore(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError($"GameManager::AddScore() => Can't add a negative score, value: {amount}");

            return;
        }

        Score += amount;
    }

    private int gridIteration = 1;

    private void RespawnGrid()
    {
        Instantiate(EnemyGridPrefab, new Vector3(0f, GridYStart - gridIteration * 0.5f), Quaternion.identity);

        gridIteration = gridIteration++ % 11;
    }
}
