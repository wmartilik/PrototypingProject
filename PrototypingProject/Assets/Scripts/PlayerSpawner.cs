using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    FirstPersonController cc;
    Renderer[] renderers;
    public Behaviour[] playerScripts;

    public ParticleSystem deathParticles;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<FirstPersonController>();
        renderers = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }
    public void Respawn()
    {
        StartCoroutine(RespawnCoroutine(GetRandomSpawn()));
    }

    Vector3 GetRandomSpawn()
    {
        return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
    }

    IEnumerator RespawnCoroutine(Vector3 spawnPos)
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        cc.enabled = false;
        SetPlayerState(false);
        transform.position = spawnPos;
        
        yield return new WaitForSeconds(3f);

        transform.position = spawnPos;
        cc.enabled = true;
        SetPlayerState(true);
    }

    void SetPlayerState(bool state)
    {
        foreach(var playerScript in playerScripts)
        {
            playerScript.enabled = state;
        }
        foreach (var renderer in renderers)
        {
            renderer.enabled = state;
        }
    }
}
