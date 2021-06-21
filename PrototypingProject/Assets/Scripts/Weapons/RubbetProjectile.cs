using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbetProjectile : MonoBehaviour
{
    PlayerHealth enemyHealth;
    public GameObject fx;
    Rigidbody rb;
    int bounces;
    public float radius = 5;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 50, 0, ForceMode.Impulse);
    }
    private void Update()
    {
        if (bounces >= 2)
        {
            Explode();
            DestroyRubbet();
        }
    }
    void DestroyRubbet()
    {
        Debug.Log("destroying rubbet");

        Destroy(gameObject.transform.parent.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounces += 1;
        Debug.Log(bounces);

        if (collision.gameObject.GetComponent<FirstPersonController>())
        {
            enemyHealth = collision.gameObject.GetComponent<PlayerHealth>();
            DamagePlayer();
        }
        else
        {
            rb.AddRelativeForce(0, 0, -25, ForceMode.Impulse);
        }
    }

    void Explode()
    {
        Vector3 explodePos = transform.position;

        Collider[] colliders = Physics.OverlapSphere(explodePos, radius);
        Instantiate(fx,transform.position,transform.rotation);

        foreach (Collider hit in colliders)
        {
            PlayerHealth ph = hit.GetComponent<PlayerHealth>();

            if (ph != null)
            {
                DamagePlayer();
            }
        }
    }
    void DamagePlayer()
    {
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(80);
        }
    }
}
