using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    CapsuleCollider player_check;
    GameObject player;
    Rigidbody rb;

    public float force_amount = 10;

    void Start()
    {
        player_check = gameObject.GetComponent<CapsuleCollider>();
        player = GameObject.Find("PlayerNew");
        rb = player.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Player")
        {
            Debug.Log("PLAYER HIT");
            rb.AddForce(transform.forward * force_amount);
        }
    }
}
