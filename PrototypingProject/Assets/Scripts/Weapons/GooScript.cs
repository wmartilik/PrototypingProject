using MLAPI.Messaging;
using UnityEngine;

public class GooScript : MonoBehaviour
{
    PlayerHealth enemyHealth;
    public GameObject gooObject;
    Transform gooSpawn;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<FirstPersonController>())
        {
            enemyHealth = collision.gameObject.GetComponent<PlayerHealth>();
            gooSpawn.position = collision.GetContact(0).point;
            DamagePlayerServerRPC();
        }

    }

    [ServerRpc] //client --> server
    void DamagePlayerServerRPC()
    {
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(10);
        }

        DamagePlayerClientRPC();
    }
    [ClientRpc] //server --> client
    void DamagePlayerClientRPC()
    {
        Instantiate(gooObject, gooSpawn.position, Quaternion.identity);
    }
}
