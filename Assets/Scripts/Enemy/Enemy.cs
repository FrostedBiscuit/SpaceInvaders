using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyRow ParentRow;

    private IParentProvider<EnemyRow> parentRowProvider;
    private IEliminationProvider<List<GameObject>> enemyEliminationProvider;
    private IScoreProvider playerScoreProvider;

    private void Awake()
    {
        parentRowProvider = GetComponent<IParentProvider<EnemyRow>>();
        enemyEliminationProvider = GetComponent<IEliminationProvider<List<GameObject>>>();
        playerScoreProvider = GameManager.instance.GetComponent<IScoreProvider>();
    }

    void Start()
    {
        ParentRow = parentRowProvider.GetParent();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Barrier" || col.transform.tag == "EnemyProjectile") 
        { 
            return;
        }

        playerScoreProvider.AddScore(ParentRow.EnemyScoreValue);

        enemyEliminationProvider.Eliminate(ParentRow.Enemies);
    }
}
