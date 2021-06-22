using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float destroyIn = 5;

    void Start()
    {
        StartCoroutine(Wait(destroyIn));
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);   //Wait
        Destroy(gameObject);
    }
}
