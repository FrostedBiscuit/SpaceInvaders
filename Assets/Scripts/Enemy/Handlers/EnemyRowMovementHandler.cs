using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyRowMovementHandler : MonoBehaviour, IMovementHandler<EnemyRow>
{
    private const float InitialRowMoveDelayPeriod = 0.25f;

    private float currentRowMoveDelayPeriod = InitialRowMoveDelayPeriod;

    private int lastEnemyCount = int.MaxValue;

    private bool forceMoveHorizontal = false;

    public void HandleMovement(ICollection<EnemyRow> enemyRows)
    {
        var newEnemyCount = countRows(enemyRows);

        if (lastEnemyCount == int.MaxValue)
        {
            lastEnemyCount = newEnemyCount;
        }
        else if (lastEnemyCount > newEnemyCount)
        {
            for (int i = 0; i < lastEnemyCount - newEnemyCount; i++)
            {
                currentRowMoveDelayPeriod -= currentRowMoveDelayPeriod * 0.2f;
            }

            lastEnemyCount = newEnemyCount;
        }

        if (enemyRows.Any(er => er.ShouldMoveDown) && forceMoveHorizontal == false)
        {
            float delay = 0f;
        
            foreach (var er in enemyRows)
            {
                er.Invoke("MoveDown", delay);
        
                delay += currentRowMoveDelayPeriod;
            }
        
            forceMoveHorizontal = true;
        }
        else
        {
            float delay = 0f;
        
            foreach (var er in enemyRows)
            {
                er.Invoke("MoveHorizontal", delay);
        
                delay += currentRowMoveDelayPeriod;
            }
        
            forceMoveHorizontal = false;
        }
    }

    private int countRows(ICollection<EnemyRow> enemyRows)
    {
        var result = 0;

        foreach (EnemyRow enemyRow in enemyRows)
        {
            result += enemyRow.Enemies.Count;
        }

        return result;
    }
}
