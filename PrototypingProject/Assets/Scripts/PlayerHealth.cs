using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkVariable;

public class PlayerHealth : NetworkBehaviour
{
    //make a synchronizable variable to store health
    NetworkVariableInt health = new NetworkVariableInt(new NetworkVariableSettings { WritePermission = NetworkVariablePermission.OwnerOnly}, 100);

    PlayerSpawner playerSpawner;

    private void Start()
    {
        playerSpawner = GetComponent<PlayerSpawner>();

    }

    void Update()
    {
        if (health.Value <= 0 && IsLocalPlayer)
        {
            health.Value = 100;
            playerSpawner.Respawn();
        }
    }

    //runs on server
    public void TakeDamage(int damage)
    {
        health.Value -= damage;
    }
}
