using UnityEngine;

public class RubbetShooting : MonoBehaviour
{

    public GameObject projectile;
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
        if (Input.GetButton("Fire") && timer >= 2f)
        {
            Debug.Log("Shot");

            //actually shoot
            Shoot();
            timer = 0;
        }

            ChargeAttack();
    }
    void ChargeAttack()
    {
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            indicator.color = Color.green;
            timer = 2f;
            Debug.Log("Charged!");
        }
        else if (timer <= 0f)
        {
            indicator.color = Color.red;
            timer = 0f;
            Debug.Log("Depleted!");
        }
    }
    void Shoot()
    {
        Instantiate(projectile, gameObject.transform.position, transform.rotation);
        indicator.color = Color.red;
    }
}
