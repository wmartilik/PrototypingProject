using MLAPI;
using MLAPI.Messaging;
using UnityEngine;

public class GooGunShooting : NetworkBehaviour
{

    public GameObject goo;
    public float distance = 15;
    public Transform gunbarrel;
    bool isShooting;

    public float timer;
    public float chargeTime;

    private void Start()
    {
        timer = chargeTime;
    }

    void Update()
    {
        if (IsLocalPlayer)
        {
            gunbarrel = gameObject.transform;

            //shoot
            if (Input.GetButton("Fire") && timer > 0f)
            {
                isShooting = true;
                Debug.Log("Shooting...");

                //actually shoot - Tell server that we have shot
                ShootServerRPC();
                DepleteAttack();
            }
            if (!Input.GetButton("Fire") && timer < 2f)
            {
                isShooting = false;
                Debug.Log("recharging...");

                ChargeAttack();
            }
        }
    }
    void ChargeAttack()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            timer = 2f;
            Debug.Log("Charged!");
        }
        else if (timer < 0f)
        {
            timer = 0f;
            Debug.Log("Depleted!");
        }
    }
    void DepleteAttack()
    {
        timer -= Time.deltaTime;
        if (timer > 2f)
        {
            timer = 2f;
            Debug.Log("Charged!");
        }
        else if (timer < 0f)
        {
            timer = 0f;
            Debug.Log("Depleted!");
        }
    }


    [ServerRpc] //client --> server
    void ShootServerRPC()
    {
        ShootClientRPC();
    }

    [ClientRpc] //server --> client
    void ShootClientRPC()
    {
        Instantiate(goo, gameObject.transform.position, gameObject.transform.rotation);
    }
}
