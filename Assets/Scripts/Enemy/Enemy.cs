﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyRow ParentRow;

    void Start()
    {
        ParentRow = transform.parent.GetComponent<EnemyRow>();
    }

    void OnCollisionEnter2D()
    {
        ParentRow.Enemies.Remove(gameObject);

        Destroy(gameObject);
    }
}