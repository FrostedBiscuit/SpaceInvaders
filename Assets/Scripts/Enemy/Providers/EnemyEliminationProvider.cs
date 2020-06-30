using System.Collections.Generic;
using UnityEngine;

public class EnemyEliminationProvider : MonoBehaviour, IEliminationProvider<List<GameObject>>
{
    public void Eliminate(List<GameObject> enemies)
    {
        enemies.Remove(gameObject);

        Destroy(gameObject);
    }
}
