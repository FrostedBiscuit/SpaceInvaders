using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyRow : MonoBehaviour
{
    private const float MaxXMove = 7.5f;
    private const float StartSpeed = 20f;
    private const float SpeedIncrement = 1f;

    private static float Speed = StartSpeed;

    private enum Direction
    {
        Left,
        Right
    }

    private Direction MoveDir = Direction.Right;

    [SerializeField]
    private float StartY = 6.5f;
    [SerializeField]
    private float StartDelay = 1f;

    [SerializeField]
    private Transform SpawnPoint;

    [SerializeField]
    private List<GameObject> Enemies;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("MoveEnemies", StartDelay);
    }

    private void MoveEnemies()
    {
        if (Enemies.Any(e => Mathf.Abs(e.transform.position.x) >= MaxXMove))
        {
            transform.position += (Vector3)Vector2.down * 0.5f;

            MoveDir = MoveDir == Direction.Right ? Direction.Left : Direction.Right;

            Invoke("MoveEnemies", 60f / Speed);

            return;
        }

        for (int i = Enemies.Count - 1; i >= 0; i--)
        {
            if (Enemies[i] == null)
            {
                Enemies.RemoveAt(i);

                Speed += SpeedIncrement;

                continue;
            }

            Enemies[i].transform.position += MoveDir == Direction.Left ? (Vector3)Vector2.left * 0.5f : (Vector3)Vector2.right * 0.5f;
        }

        Invoke("MoveEnemies", 60f / Speed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(0f, transform.position.y), new Vector3(MaxXMove, transform.position.y));
        Gizmos.DrawLine(new Vector3(0f, transform.position.y), new Vector3(-MaxXMove, transform.position.y));
    }
}
