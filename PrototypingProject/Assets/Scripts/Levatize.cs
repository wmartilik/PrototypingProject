using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levatize : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject platform;
    public float max_height = 10.0f;
    private bool going_up = true;
    public bool reversed = false;

	void Start()
	{
        if (reversed == true)
		{
            transform.Translate(Vector3.up * -max_height);
		}
	}

	void Update()
    {
        
        if(platform.transform.position.y <= max_height && going_up)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed, platform.transform);
        }
        else if (platform.transform.position.y >= max_height && going_up)
        {
            going_up = false;
        }
        if(platform.transform.position.y >= 0 && !going_up)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed, platform.transform);
        }
        else if (platform.transform.position.y <= 0 && !going_up)
        {
            going_up = true;
        }
    }
    
  
}
