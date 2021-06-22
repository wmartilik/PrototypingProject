using UnityEngine;

public class GooGunShooting : MonoBehaviour
{

    public GameObject goo;
    public Material indicator;
    public Transform gunbarrel;

    public float timer;
    public float chargeTime;

    private void Start()
    {
        timer = chargeTime;
        indicator.color = Color.green;
    }

    void Update()
    {
        gunbarrel = gameObject.transform;

        //shoot
        if (Input.GetButtonDown("Fire"))
        {
            GetComponent<AudioSource>().Play();
        }
        else if (Input.GetButtonUp("Fire"))
        {
            GetComponent<AudioSource>().Stop();
        }

        if (Input.GetButton("Fire") && timer > 0f)
        {
            Debug.Log("Shooting...");

            //actually shoot
            Shoot();
            DepleteAttack();
        }
        if (!Input.GetButton("Fire") && timer < 2f)
        {
            Debug.Log("recharging...");

            ChargeAttack();
        }
    }
    void ChargeAttack()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            indicator.color = Color.green;
            timer = 2f;
            Debug.Log("Charged!");
        }
        else if (timer < 2f && timer >= 0)
        {
            indicator.color = Color.yellow;
        }
        else if (timer <= 0f)
        {
            indicator.color = Color.red;
            timer = 0f;
            Debug.Log("Depleted!");
        }
    }
    void DepleteAttack()
    {
        timer -= Time.deltaTime;
        if (timer > 2f)
        {
            indicator.color = Color.green;
            timer = 2f;
            Debug.Log("Charged!");
        }
        else if (timer < 2f && timer > 0)
        {
            indicator.color = Color.yellow;
        }
        else if (timer <= 0f)
        {
            indicator.color = Color.red;
            timer = 0f;
            GetComponent<AudioSource>().Stop();
            Debug.Log("Depleted!");
        }
    }
    void Shoot()
    {
        Instantiate(goo, gameObject.transform.position, gameObject.transform.rotation);
    }
}
