using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0;
    public float dmgMultiplier = 1f;

    public void TakeDamage(float damage)
    {
        health += damage * dmgMultiplier;
    }
}
