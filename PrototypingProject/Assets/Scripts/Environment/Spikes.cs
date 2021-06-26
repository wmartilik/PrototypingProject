using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    CapsuleCollider player_check;
    GameObject player;
    

    public float force_amount = 100000;

    void Start()
    {
        player_check = gameObject.GetComponent<CapsuleCollider>();
        player = GameObject.Find("PlayerNew");
        
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Player")
        {
            Debug.Log("PLAYER HIT");
        }
    }
}
