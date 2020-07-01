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

        playerScoreProvider = GetComponent<IScoreProvider>();
    }
    #endregion

    private const float GridYStart = 6.5f;

    public int Score { get { return playerScoreProvider.Score; } }
    public int HighScore { get { return playerScoreProvider.HighScore; } }

    [SerializeField]
    private GameObject EnemyGridPrefab;
    [SerializeField]
    private GameObject DefeatPanel;

    private IScoreProvider playerScoreProvider;

    private void Start()
    {
        playerScoreProvider.Init();
    }

    public void PlayerWon()
    {
        Invoke("RespawnGrid", 1f);
    }

    public void PlayerLost()
    {
        // Probably display a "try again" panel here

        DefeatPanel.SetActive(true);

        playerScoreProvider.SaveHighScore();
    }

    public void ReloadLevel()
    {
        PlayerHealth.Lives = 3;

        SceneManager.LoadScene("Main");
    }

    private int gridIteration = 1;

    private void RespawnGrid()
    {
        Instantiate(EnemyGridPrefab, new Vector3(0f, GridYStart - gridIteration * 0.5f), Quaternion.identity);

        gridIteration = gridIteration++ % 11;
    }
}