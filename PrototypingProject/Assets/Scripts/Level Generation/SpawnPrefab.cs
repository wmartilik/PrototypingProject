using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
	public GameObject[] objects;

	private void Start()
	{
		int rand = Random.Range(0, objects.Length);
		if (objects[rand] != null)
		{
			GameObject instance = (GameObject)Instantiate(objects[rand], transform.position, Quaternion.identity);
		}
	}
}
