using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyProjectileSpawnPointProvider : MonoBehaviour, ISpawnPointProvider<Transform>
{
    public ICollection<Transform> GetSpawnPoints(ICollection spawnPointPool)
    {
        var enemySpawnPointPool = spawnPointPool as ICollection<EnemyRow>;

        EnemyRow invRow;
        
        try
        {
            invRow = enemySpawnPointPool.First(esp => esp.Enemies.Count > 0);
        }
        catch
        {
            return null;
        }

        var numberOfShots = Random.Range(0, 3);
        var numberToTake = Mathf.Clamp(numberOfShots, 1, invRow.Enemies.Count);

        return invRow.Enemies.Take(numberToTake).Select(er => er.transform).ToList();
    }
}
