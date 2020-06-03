using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    public const float MaxXMove = 7.5f;

    [SerializeField]
    private EnemyRow[] EnemyRows;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MovementLoop", 1f, 1f);
    }

    bool forceMoveHorizontal = false;

    private void MovementLoop()
    {
        if (EnemyRows.Any(er => er.ShouldMoveDown) && forceMoveHorizontal == false)
        {
            Debug.Log("Rows moving down");

            foreach (var er in EnemyRows)
            {
                er.MoveDown();
            }

            forceMoveHorizontal = true;
        }
        else
        {
            Debug.Log("Rows moving horizontally");

            foreach (var er in EnemyRows)
            {
                er.MoveHorizontal();
            }

            forceMoveHorizontal = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
