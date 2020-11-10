using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float total_time = 300.0f;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        this.isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if(this.total_time > 0.0f)
            {
                this.total_time -= Time.deltaTime;
            }
        }

        else
        {
            this.GetComponentInParent<Text>().text = "TIME'S OUT!";
            this.total_time = 0.0f;
            this.isRunning = false;
        }


        this.DisplayTime(this.total_time);
    }

    private void DisplayTime(float runningTime)
    {
        float min = Mathf.FloorToInt(runningTime / 60);
        float secs = Mathf.FloorToInt(runningTime % 60);

        this.GetComponentInParent<Text>().text = "Timer: " + min.ToString() + ":" + secs.ToString();
    }
}
