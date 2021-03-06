﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float YKill = 50f;

    [SerializeField]
    private Vector2 StartVelocity;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(StartVelocity);
    }

    void Update()
    {
        if (YKill > 0)
        {
            if (transform.position.y > YKill)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.position.y < YKill)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (transform.tag == "EnemyProjectile" && col.transform.tag == "PlayerProjectile" && Random.Range(0, 50) > 35)
        {
            return;
        }

        Destroy(gameObject);
    }
}
