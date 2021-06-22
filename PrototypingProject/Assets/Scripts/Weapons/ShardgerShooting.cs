using UnityEngine;

public class ShardgerShooting : MonoBehaviour
{
    public Material indicator;
    public TrailRenderer bulletTrail;
    public float distance = 15;
    public Transform gunbarrel;
    public GameObject fx = null;
    private float rand;

    public float timer;
    public float chargeTime;


    private void Start()
    {
        timer = 3;
        indicator.color = Color.red;

    }

    void Update()
    {
            if (Input.GetButton("Fire"))
            {
                ChargeAttack();
            }
            //shoot
            if (Input.GetButtonUp("Fire") && timer <= 0f)
            {
                //actually shoot - Tell server that we have shot
                Shoot();
                timer = chargeTime;
                indicator.color = Color.red;
            }
            else if (Input.GetButtonUp("Fire"))
            {
                indicator.color = Color.red;
                timer = chargeTime;
            }

        rand = Random.Range(-0.5f, 0.5f);
    }
    void ChargeAttack()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            indicator.color = Color.green;
            timer = 0f;
            Debug.Log("Charged!");
        }
        else
        {
            indicator.color = Color.red;
        }
    }

    void Shoot()
    {
        GetComponent<AudioSource>().Play();

        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;

        var bullet = Instantiate(bulletTrail, gunbarrel.position, Quaternion.identity);
        var bullet1 = Instantiate(bulletTrail, gunbarrel.position + new Vector3(-rand, rand, rand), Quaternion.identity);
        var bullet2 = Instantiate(bulletTrail, gunbarrel.position + new Vector3(rand, -rand, rand), Quaternion.identity);
        var bullet3 = Instantiate(bulletTrail, gunbarrel.position + new Vector3(rand, rand, rand), Quaternion.identity);

        bullet.AddPosition(gunbarrel.position);
        bullet1.AddPosition(gunbarrel.position);
        bullet2.AddPosition(gunbarrel.position);
        bullet3.AddPosition(gunbarrel.position);

        //do raycast
        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward, out hit, distance))
        {
            var enemyHealth = hit.transform.GetComponent<PlayerHealth>();
            bullet.transform.position = hit.point;
            Instantiate(fx, hit.point, Quaternion.identity);

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(40);
            }
        }
        else bullet.transform.position = gunbarrel.position + (gunbarrel.forward * 15);

        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward + new Vector3(-.2f, 0f, 0f), out hit1, distance))
        {
            var enemyHealth = hit1.transform.GetComponent<PlayerHealth>();
            bullet1.transform.position = hit1.point;
            Instantiate(fx, hit1.point, Quaternion.identity);

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
        }
        else bullet1.transform.position = gunbarrel.position + ((gunbarrel.forward + new Vector3(-.2f, 0f, 0f)) * 15);
        

        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward + new Vector3(0f, -.1f, 0f), out hit2, distance))
        {
            var enemyHealth = hit2.transform.GetComponent<PlayerHealth>();
            bullet2.transform.position = hit2.point;
            Instantiate(fx, hit2.point, Quaternion.identity);

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
        }
        else bullet2.transform.position = gunbarrel.position + ((gunbarrel.forward + new Vector3(0f, -.1f, 0f)) * 15);
        
        if (Physics.Raycast(gunbarrel.position, gunbarrel.forward + new Vector3(0f, .1f, 0f), out hit3, distance))
        {
            var enemyHealth = hit3.transform.GetComponent<PlayerHealth>();
            bullet3.transform.position = hit3.point;
            Instantiate(fx, hit3.point, Quaternion.identity);

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
        }
        else bullet3.transform.position = gunbarrel.position + ((gunbarrel.forward + new Vector3(0f, .1f, 0f)) * 15);

    }
}
