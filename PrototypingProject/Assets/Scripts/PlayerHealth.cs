using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 0;
    public void TakeDamage(int damage)
    {
        health += damage;
    }
}
