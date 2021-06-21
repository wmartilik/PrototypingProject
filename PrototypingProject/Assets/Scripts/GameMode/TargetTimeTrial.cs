using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetTimeTrial : MonoBehaviour
{

    private GameObject player;
    
    private GameObject timer;
    
    private GameObject score;

    private float time_remaining = 180;

    private bool timer_running;

    private Text time_text;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerNew");
        timer = GameObject.Find("Timer");
        score = GameObject.Find("Score");
        time_text = timer.GetComponent<Text>();
        timer_running = true;
    }

    // Update is called once per frame
    void Update()
    {   
        if (time_text != null)
        {
            if (timer_running)
            {
                if (time_remaining > 0)
                {
                    time_remaining -= Time.deltaTime;
                }
                else
                {
                    time_remaining = 0;
                    timer_running = false;
                }
            }
            TimeDisplay(time_remaining);
        }
        
    }

    void TimeDisplay(float _time)
    {
        _time += 1;

        float min = Mathf.FloorToInt(_time / 60);
        float sec = Mathf.FloorToInt(_time % 60);

        time_text.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
