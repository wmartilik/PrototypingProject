using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public TrailRenderer bulletTrail;

    public Transform gunbarrel;
    public GameObject fx = null;


	void Update()
    {
        if (Input.GetButtonUp("Fire"))
        {
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
            Instantiate(fx, hit.point, Quaternion.identity);

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

        GetComponent<AudioSource>().Play();
    }
}
