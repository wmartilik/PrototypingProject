using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public TrailRenderer bulletTrail;

    public Transform gunbarrel;

    void Update()
    {
            //shoot
            if (Input.GetButtonDown("Fire"))
            {
                //actually shoot
                Shoot();
            }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletTrail, gunbarrel.position, Quaternion.identity);
        bullet.AddPosition(gunbarrel.position);
        if(Physics.Raycast(gunbarrel.position,gunbarrel.forward, out RaycastHit hit, 15))
        {
            bullet.transform.position = hit.point;

            var enemyHealth = hit.transform.GetComponent<PlayerHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(5);
            }
        }
        else
        {
            bullet.transform.position = gunbarrel.position + (gunbarrel.forward * 15);
        }
    }
}
