using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject Projectile;

    [SerializeField]
    private Transform GunTransform;

    private GameObject shot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && shot == null)
        {
            //Debug.Log("Shooting...");

            shot = Instantiate(Projectile, GunTransform.position, GunTransform.rotation);
        }
    }
}
