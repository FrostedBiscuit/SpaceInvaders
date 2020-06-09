using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int Lives = 3;

    private void OnCollisionEnter2D()
    {
        Debug.Log("Player was hit");

        Lives = Mathf.Max(0, Lives - 1);

        if (Lives == 0)
        {
            GameManager.instance.PlayerLost();

            Destroy(gameObject);
        }
    }
}
