using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    PlayerSpawner playerSpawner;

    private void Start()
    {
        playerSpawner = GetComponent<PlayerSpawner>();

    }

    void Update()
    {
        if (health <= 0)
        {
            health = 100;
            playerSpawner.Respawn();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
