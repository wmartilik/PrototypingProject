using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class PlayerShooting : NetworkBehaviour
{

    public TrailRenderer bulletTrail;

    public Transform gunbarrel;

    void Update()
    {
        if (IsLocalPlayer)
        {
            //shoot
            if (Input.GetButtonDown("Fire"))
            {
                //actually shoot - Tell server that we have shot
                ShootServerRPC();
            }
        }
    }

    [ServerRpc] //client --> server
    void ShootServerRPC()
    {
        //do raycast on the server
        if (Physics.Raycast(gunbarrel.position,gunbarrel.forward, out RaycastHit hit, 15))
        {
            var enemyHealth = hit.transform.GetComponent<PlayerHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
        }
        ShootClientRPC();
    }

    [ClientRpc] //server --> client
    void ShootClientRPC()
    {
        var bullet = Instantiate(bulletTrail, gunbarrel.position, Quaternion.identity);
        bullet.AddPosition(gunbarrel.position);
        if(Physics.Raycast(gunbarrel.position,gunbarrel.forward, out RaycastHit hit, 15))
        {
            bullet.transform.position = hit.point; 
        }
        else
        {
            bullet.transform.position = gunbarrel.position + (gunbarrel.forward * 15);
        }
    }
}
