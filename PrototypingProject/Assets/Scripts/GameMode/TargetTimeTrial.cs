using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetTimeTrial : MonoBehaviour
{

    private GameObject player;

    private GameObject timer;

    private GameObject score;

    [SerializeField]
    PlayerHealth score_points;

    [SerializeField]
    private GameObject results;

    private float time_remaining = 3;

    private bool timer_running;

    private Text time_text;

    private Text score_text;

    [SerializeField]
    private AudioClip beep;

    private AudioSource audio;

    private int previous_sec = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerNew");
        timer = GameObject.Find("Timer");
        score = GameObject.Find("Score");
        time_text = timer.GetComponent<Text>();
        score_text = score.GetComponent<Text>();
        timer_running = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer_running)
        {
            if (time_remaining > 0)
            {
                time_remaining -= Time.deltaTime;
                if (time_remaining <= 61 && time_remaining > 11)
                {
                    time_text.color = Color.yellow;
                }
                else if (time_remaining <= 11)
                {
                    time_text.color = Color.red;
                }

            }
            else if (time_remaining <= 0)
            {
                time_remaining = 0;
                Time.timeScale = 0;
                player.GetComponent<FirstPersonController>().enabled = false;
                ResultsScreen();
                timer_running = false;
                Debug.Log("FINISHED");
            }
        }
        TimeDisplay(time_remaining);
        ScoreDisplay(score_points.health);
        if (score_points.health >= 100 & score_points.health < 500)
        {
            score_text.color = Color.yellow;
        }
        else if (score_points.health >= 500 & score_points.health < 1000)
        {
            score_text.color = Color.green;
        }
        else if (score_points.health >= 1000)
        {
            score_text.color = Color.cyan;
        }
        //if (time_remaining == 0)
        //{
        //    Time.timeScale = 0;

        //    ResultsScreen(100);
        //}


    }

    void TimeDisplay(float _time)
    {
        float min = Mathf.FloorToInt(_time / 60);
        float sec = Mathf.FloorToInt(_time % 60);

        if ((int)sec <= 10 && sec != previous_sec && min <= 0)
        {
            previous_sec = (int)sec;
            gameObject.GetComponent<AudioSource>().Play();
        }
        time_text.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    void ScoreDisplay(float _score)
    {
        score_text.text = _score.ToString();
    }

    void ResultsScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        results.SetActive(true);

        if (score_points.health >= 100 & score_points.health < 500)
        {
            results.GetComponentInChildren<Text>().color = Color.yellow;
        }
        else if (score_points.health >= 500 & score_points.health < 1000)
        {
            results.GetComponentInChildren<Text>().color = Color.green;
        }
        else if (score_points.health >= 1000)
        {
            results.GetComponentInChildren<Text>().color = Color.cyan;
        }
        results.GetComponentInChildren<Text>().text = score_text.text;
    }
}