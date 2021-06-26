using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    BoxCollider Collider;

    Rigidbody rb;   

    private float time_remaining = 0.75f;

    private bool timer_running;

    private bool trigger_trap = false;

    private bool reset_trap = false;

    private float original_position;

    private float speed = 700;

    private bool force_added = false;

   
    void Start()
    {
        Collider = gameObject.GetComponent<BoxCollider>();
        rb = gameObject.GetComponent<Rigidbody>();       
    }

        void Update()
    {
        if (timer_running)
        {
            if (time_remaining > 0)
            {
                time_remaining -= Time.deltaTime;
            }
            else if (time_remaining <= 0)
            {
                time_remaining = 0.75f;                   
                timer_running = false;
                trigger_trap = true;                
            }
        }
        if (trigger_trap)
        {
            if (!reset_trap)
            {
                TrapMotionForward();
            }
            else if (reset_trap)
            {
                ReturnTrapOriginal();
            }           
        }
    }

    void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Player" && timer_running != true)
        {
            timer_running = true;            
        }        
    }

    void TrapMotionForward()
    {
        RaycastHit hit;
        Ray distance_ray = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(distance_ray, out hit))
        {
            
            float distance_check = hit.distance;
            
           
            if (distance_check > 2.0f)
            {
                // transform.Translate(Vector3.forward * speed * Time.deltaTime);
              if (!force_added)
                {
                    rb.AddForce(transform.forward * speed);
                    force_added = true;
                }                
            }
            if (distance_check <= 2.0f)
            {
                Vector3 temp_vec = new Vector3(0.0f, 0.0f, 0.0f);
                rb.velocity = temp_vec;
                reset_trap = true;
            }
        }
    }

    void ReturnTrapOriginal()
    {
        RaycastHit hit;
        Ray distance_ray = new Ray(transform.position, Vector3.back);
        if (Physics.Raycast(distance_ray, out hit))
        {

            float distance_check = hit.distance;


            if (distance_check > 0.2f)
            {
                transform.Translate(Vector3.back * Time.deltaTime);                
            }
            if (distance_check <= 0.5f)
            {
                reset_trap = false;
                trigger_trap = false;
                force_added = false;
            }
        }      
    }

  
}
