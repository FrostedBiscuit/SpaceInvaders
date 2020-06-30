using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyRow ParentRow;

    private IParentProvider<EnemyRow> parentRowProvider;
    private IEliminationProvider<List<GameObject>> enemyEliminationProvider;

    private void Awake()
    {
        parentRowProvider = GetComponent<IParentProvider<EnemyRow>>();
        enemyEliminationProvider = GetComponent<IEliminationProvider<List<GameObject>>>();
    }

    void Start()
    {
        ParentRow = parentRowProvider.GetParent();
    }

    void OnCollisionEnter2D()
    {
        GameManager.instance.AddScore(ParentRow.EnemyScoreValue);

        enemyEliminationProvider.Eliminate(ParentRow.Enemies);
    }
}
