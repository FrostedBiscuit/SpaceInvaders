using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    public const float MaxXMove = 7.5f;
    public const float InitialMovementPeriod = 3f;
    public const float InitialRowMoveDelayPeriod = 0.25f;
    public const float EnemyAttackPeriod = 1f;

    [SerializeField]
    private GameObject EnemyProjectile;

    [SerializeField]
    private EnemyRow[] EnemyRows;

    private int lastEnemyCount = 0;

    private float currentMovementPeriod = InitialMovementPeriod;
    private float currentRowMoveDelayPeriod = InitialRowMoveDelayPeriod;

    // Start is called before the first frame update
    void Start()
    {
        lastEnemyCount = CalculateEnemyCount();

        Invoke("MovementLoop", 1f);
    }

    bool forceMoveHorizontal = false;

    private void MovementLoop()
    {
        if (EnemyRows.Any(er => er.transform.position.y <= 1f && er.Enemies.Count > 0) || PlayerHealth.Lives == 0)
        {
            // Player has lost...
            Debug.Log("Player has lost");

            GameManager.instance.PlayerLost();

            return;
        }

        int currentEnemyCount = CalculateEnemyCount();

        if (currentEnemyCount < lastEnemyCount)
        {
            // 1 or more enemies have been killed, let's decrease movement period
            // by the appropriate amount
            for (int i = 0; i < lastEnemyCount - currentEnemyCount; i++)
            {
                currentMovementPeriod = currentMovementPeriod - currentMovementPeriod * 0.2f;
                currentRowMoveDelayPeriod = currentRowMoveDelayPeriod - currentRowMoveDelayPeriod * 0.2f;
            }

            lastEnemyCount = currentEnemyCount;
        }

        // Check if enemies should move down a row
        if (EnemyRows.Any(er => er.ShouldMoveDown) && forceMoveHorizontal == false)
        {
            Debug.Log("Rows moving down");

            float delay = 0f;

            foreach (var er in EnemyRows)
            {
                er.Invoke("MoveDown", delay);

                delay += currentRowMoveDelayPeriod;
            }

            forceMoveHorizontal = true;
        }
        else
        {
            Debug.Log("Rows moving horizontally");

            float delay = 0f;

            foreach (var er in EnemyRows)
            {
                er.Invoke("MoveHorizontal", delay);

                delay += currentRowMoveDelayPeriod;
            }

            forceMoveHorizontal = false;
        }

        if (EnemyRows.Any(er => er.Enemies.Count > 0))
        {
            Invoke("MovementLoop", currentMovementPeriod);
        }
        else
        {
            GameManager.instance.PlayerWon();
        }
    }

    private void EnemiesAttack()
    {
        System.Random random = new System.Random();

        EnemyRow invasionRow = EnemyRows.First(er => er.Enemies.Count > 0);

        // Scramble enemies which are candidates for firing projectile
        IEnumerable<GameObject> enemiesToFire = invasionRow.Enemies.OrderBy(e => random.Next()).Take(Random.Range(0, 4));

        // Instantiate the projectile objects for each enemy we selected before
        foreach (var e in enemiesToFire)
        {
            Instantiate(EnemyProjectile, e.transform.position + (Vector3)Vector2.down * -0.25f, Quaternion.identity);
        }
    }

    private int CalculateEnemyCount()
    {
        int result = 0;

        foreach (var er in EnemyRows)
        {
            result += er.Enemies.Count;
        }

        return result;
    }
}
