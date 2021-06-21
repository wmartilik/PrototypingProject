using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathNet : MonoBehaviour
{
    private Vector3 startPosition;

    public GameObject player;

    void Awake()
    {
        startPosition = player.gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dead");

        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = startPosition;
        }
    }
}
