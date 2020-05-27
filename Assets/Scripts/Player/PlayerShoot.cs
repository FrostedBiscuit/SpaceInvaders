using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject Projectile;

    [SerializeField]
    private Transform GunTransform;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Shooting...");

            Instantiate(Projectile, GunTransform.position, GunTransform.rotation);
        }
    }
}
