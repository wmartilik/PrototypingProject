using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbetProjectile : MonoBehaviour
{
    public GameObject fx;
    Rigidbody rb;
    int bounces;
    public float radius = 20;
    PlayerHealth ph;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 5, 0, ForceMode.Impulse);
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
            DamagePlayer(ph, 80);
        }
        else
        {
            rb.AddRelativeForce(0, -5, 0, ForceMode.Impulse);
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

            Debug.Log(ph);

            if (ph != null)
            {
                DamagePlayer(ph, 60);
            }
        }
    }
    void DamagePlayer(PlayerHealth ph, int damageValue)
    {
        if (ph != null)
        {
            ph.TakeDamage(80);
        }
    }
}
