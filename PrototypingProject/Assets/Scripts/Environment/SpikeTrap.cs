using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    BoxCollider Collider;   

    private float time_remaining = 1.0f;

    private bool timer_running;

    private bool trigger_trap = false;

    private bool reset_trap = false;

    private float original_position;

    public float speed = 15;


    void Start()
    {
        Collider = gameObject.GetComponent<BoxCollider>();
        
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
                time_remaining = 1.0f;                   
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
            
           
            if (distance_check > 0.2f)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);               
            }
            if (distance_check <= 0.5f)
            {
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
            }
        }      
    }
}
