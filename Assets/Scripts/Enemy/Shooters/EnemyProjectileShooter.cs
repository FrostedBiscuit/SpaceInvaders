using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileShooter : MonoBehaviour, IProjectileShooter
{
    public void Shoot(GameObject projectile, ICollection<Transform> spawnPoints)
    {
        // Instantiate the projectile objects for each enemy we selected before
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(projectile, spawnPoint.position + (Vector3)Vector2.down * -0.25f, Quaternion.identity);
        }
    }
}
