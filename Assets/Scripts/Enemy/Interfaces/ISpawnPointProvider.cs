using System.Collections;
using System.Collections.Generic;

public interface ISpawnPointProvider<TSpawnPoint>
{
    ICollection<TSpawnPoint> GetSpawnPoints(ICollection spawnPointPool);
}