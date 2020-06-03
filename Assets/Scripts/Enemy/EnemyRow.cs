using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyRow : MonoBehaviour
{
    private enum Direction
    {
        Left,
        Right
    }

    private Direction MoveDir = Direction.Right;

    public bool ShouldMoveDown => Enemies.Any(e => Mathf.Abs(e.transform.position.x) >= EnemyGrid.MaxXMove);

    public float StartDelay = 1f;

    public List<GameObject> Enemies;

    public void MoveHorizontal()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].transform.position += MoveDir == Direction.Left ? (Vector3)Vector2.left * 0.5f : (Vector3)Vector2.right * 0.5f;
        }
    }

    public void MoveDown()
    {
        transform.position += (Vector3)Vector2.down * 0.5f;

        MoveDir = MoveDir == Direction.Right ? Direction.Left : Direction.Right;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(0f, transform.position.y), new Vector3(EnemyGrid.MaxXMove, transform.position.y));
        Gizmos.DrawLine(new Vector3(0f, transform.position.y), new Vector3(-EnemyGrid.MaxXMove, transform.position.y));
    }
}
