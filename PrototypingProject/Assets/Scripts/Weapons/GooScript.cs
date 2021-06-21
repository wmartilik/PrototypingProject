using MLAPI.Messaging;
using UnityEngine;
using System.Collections;

public class GooScript : MonoBehaviour
{
    PlayerHealth enemyHealth;
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(0,2,10,ForceMode.Impulse);
    }

 IEnumerator DestroyGoo()
    {
        Debug.Log("destroying goo");

        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == true && collision.gameObject.GetComponent<FirstPersonController>() == false && collision.gameObject.name != "GooProjectile(Clone)")
        {
            //Debug.Log(collision.gameObject.name);
            //gameObject.GetComponent<Transform>().SetParent(collision.transform);
            rb.drag = 20;

        }

        if (collision.gameObject.GetComponent<FirstPersonController>())
        {
            //gameObject.transform.parent = collision.gameObject.transform;
            enemyHealth = collision.gameObject.GetComponent<PlayerHealth>();
            DamagePlayer();
        }
        StartCoroutine (DestroyGoo());
    }
    private void OnCollisionStay(Collision collision)
    {
        enemyHealth = collision.gameObject.GetComponent<PlayerHealth>();
        DamagePlayer();
    }

    void DamagePlayer()
    {
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(1);
        }
    }
}
