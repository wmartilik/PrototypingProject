using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    BoxCollider player_check;
    GameObject player;

    private float time_remaining = 0.5f;

    private bool timer_running;

    private bool trigger_trap = false;

    private bool reset_trap = false;

    private float original_position;

    private float speed = 50;

    private bool force_added = false;    

    void Start()
    {
        player_check = gameObject.GetComponent<BoxCollider>();
        player = GameObject.Find("PlayerNew");

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
                time_remaining = 0.5f;
                timer_running = false;
                trigger_trap = true;
            }
        }

        if (trigger_trap)
        {
            FloorFall();
            if (transform.position.y <= -50.0f)
            {
                Destroy(this);
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

    void FloorFall()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }
}
