using System.Collections.Generic;
using UnityEngine;

public interface IProjectileShooter
{
    void Shoot(GameObject projectile, ICollection<Transform> spawnPoints);
}
