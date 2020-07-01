using System.Linq;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    public const float MaxXMove = 7.5f;
    public const float InitialMovementPeriod = 3f;
    public const float EnemyAttackPeriod = 1f;

    [SerializeField]
    private GameObject EnemyProjectile;

    [SerializeField]
    private EnemyRow[] EnemyRows;

    private int lastEnemyCount = 0;

    private float currentMovementPeriod = InitialMovementPeriod;

    private IProjectileShooter enemyProjectileShooter;

    private ISpawnPointProvider<Transform> enemyProjectileSpawnPointProvider;

    private IMovementHandler<EnemyRow> enemyRowMovementHandler;

    private void Awake()
    {
        enemyProjectileShooter = GetComponent<IProjectileShooter>();

        enemyProjectileSpawnPointProvider = GetComponent<ISpawnPointProvider<Transform>>();

        enemyRowMovementHandler = GetComponent<IMovementHandler<EnemyRow>>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lastEnemyCount = CalculateEnemyCount();

        Invoke("MovementLoop", 1f);
    }

    private void MovementLoop()
    {
        if (Random.Range(0, 2) == 1)
        {
            enemyProjectileShooter.Shoot(EnemyProjectile, enemyProjectileSpawnPointProvider.GetSpawnPoints(EnemyRows));
        }

        if (EnemyRows.Any(er => er.transform.position.y <= 1f && er.Enemies.Count > 0) || PlayerHealth.Lives == 0)
        {
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
                currentMovementPeriod = currentMovementPeriod - (currentMovementPeriod * 0.1f);
            }

            lastEnemyCount = currentEnemyCount;
        }

        // Check if enemies should move down a row
        enemyRowMovementHandler.HandleMovement(EnemyRows);

        if (EnemyRows.Any(er => er.Enemies.Count > 0))
        {
            Invoke("MovementLoop", currentMovementPeriod);
        }
        else
        {
            GameManager.instance.PlayerWon();
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
