using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    [SerializeField] GameObject GameOverUI;
    [SerializeField] int Total_Time;
    private int current_Time;
    public static int elapsed_Time = 0;
    public static int score_Time;
    bool running = false;

    private void Start()
    {
        this.current_Time = this.Total_Time;
        score_Time = this.Total_Time;
    }

    void Update()
    {
        if (score_Time <= 0)
        {
            this.GameOverUI.SetActive(true);
            this.running = true;
        }

        if(this.running == false)
        {
            StartCoroutine(this.decreaseTime());
        }
    }

    IEnumerator decreaseTime()
    {
        this.running = true;
        elapsed_Time += 1;
        this.current_Time = this.Total_Time;
        this.current_Time -= elapsed_Time;
        score_Time = this.current_Time;
        this.gameObject.GetComponent<Text>().text = "" + this.current_Time;
        yield return new WaitForSeconds(1);
        this.running = false;
    }
}
