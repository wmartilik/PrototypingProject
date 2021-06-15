using MLAPI;
using MLAPI.Messaging;
using UnityEngine;

public class ShardgerShooting : NetworkBehaviour
{

    public TrailRenderer bulletTrail;
    public float distance = 15;
    public Transform gunbarrel;

    float timer;
    public float chargeTime;

    private void Start()
    {
        timer = 3;
    }

    void Update()
    {
        if (IsLocalPlayer)
        {
            if (Input.GetButton("Fire"))
            {
                ChargeAttack();
            }
            //shoot
            if (Input.GetButtonUp("Fire") && timer <= 0f)
            {
                //actually shoot - Tell server that we have shot
                ShootServerRPC();
                timer = chargeTime;
            }
            else if (Input.GetButtonUp("Fire"))
            {
                timer = chargeTime;
            }
        }
    }
    void ChargeAttack()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = 0f;
            Debug.Log("Charged!");
        }
    }

    [ServerRpc] //client --> server
    void ShootServerRPC()
    {
        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;


        //do raycast on the server
        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward, out hit, distance))
        {
            var enemyHealth = hit.transform.GetComponent<PlayerHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
        }
        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward + new Vector3(-.2f, 0f, 0f), out hit1, distance))
        {
            var enemyHealth = hit1.transform.GetComponent<PlayerHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
        }
        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward + new Vector3(0f, -.1f, 0f), out hit2, distance))
        {
            var enemyHealth = hit2.transform.GetComponent<PlayerHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
        }
        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward + new Vector3(0f, .1f, 0f), out hit3, distance))
        {
            var enemyHealth = hit3.transform.GetComponent<PlayerHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
        }

        ShootClientRPC();
    }

    [ClientRpc] //server --> client
    void ShootClientRPC()
    {
        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;

        var bullet = Instantiate(bulletTrail, gunbarrel.position, Quaternion.identity);
        var bullet1 = Instantiate(bulletTrail, gunbarrel.position + new Vector3(-.2f, 0f, 0f), Quaternion.identity);
        var bullet2 = Instantiate(bulletTrail, gunbarrel.position + new Vector3(0f, -.1f, 0f), Quaternion.identity);
        var bullet3 = Instantiate(bulletTrail, gunbarrel.position + new Vector3(0f, .1f, 0f), Quaternion.identity);

        bullet.AddPosition(gunbarrel.position);
        bullet1.AddPosition(gunbarrel.position);
        bullet2.AddPosition(gunbarrel.position);
        bullet3.AddPosition(gunbarrel.position);

        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward, out hit, distance))
        {
            bullet.transform.position = hit.point;
        }
        else
        {
            bullet.transform.position = gunbarrel.position + (gunbarrel.forward * 15);
        }

        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward + new Vector3(-.2f, 0f, 0f), out hit1, distance))
        {
            bullet1.transform.position = hit1.point;
        }
        else
        {
            bullet1.transform.position = gunbarrel.position + ((gunbarrel.forward + new Vector3(-.2f, 0f, 0f)) * 15);
        }

        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward + new Vector3(0f, -.1f, 0f), out hit2, distance))
        {
            bullet2.transform.position = hit2.point;
        }
        else
        {
            bullet2.transform.position = gunbarrel.position + ((gunbarrel.forward + new Vector3(0f, -.1f, 0f)) * 15);
        }

        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward + new Vector3(0f, .1f, 0f), out hit3, distance))
        {
            bullet3.transform.position = hit3.point;
        }
        else
        {
            bullet3.transform.position = gunbarrel.position + ((gunbarrel.forward + new Vector3(0f, .1f, 0f)) * 15);
        }
    }
}
