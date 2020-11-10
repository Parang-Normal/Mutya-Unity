using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] GameObject UISystem;
    [SerializeField] bool ScoreRequirement = false;
    [SerializeField] int MinimumScore = 0;

    private GameObject FinishUI;
    private GameObject HUD;
    private GameObject ObjectiveWarning;
    private int final_Time;
    private int final_score;
    private int total_score;

    private string activeUser;

    private void Start()
    {
        this.FinishUI = this.UISystem.transform.Find("FinishUI").gameObject;
        this.HUD = this.UISystem.transform.Find("HUD").gameObject;
        this.ObjectiveWarning = this.UISystem.transform.Find("ObjectiveWarning").gameObject;
    }

    private void OnTriggerEnter()
    {
        if (this.ScoreRequirement == true)
        {
            if (GlobalScore.current_Score >= this.MinimumScore)
            {
                StartCoroutine(this.trigger());
            }
            else
            {
                StartCoroutine(this.warning());
            }
        }
        else
        {
            StartCoroutine(this.trigger());
        }
    }

    IEnumerator warning()
    {
        this.ObjectiveWarning.GetComponent<Text>().text = "You only have " + GlobalScore.current_Score + " points, collect at least " + (this.MinimumScore - GlobalScore.current_Score) + " points more!";
        this.ObjectiveWarning.SetActive(true);
        yield return new WaitForSeconds(3);
        this.ObjectiveWarning.SetActive(false);
    }

    IEnumerator trigger()
    {
        SFX_Win.play = true;
        this.final_score = GlobalScore.current_Score;
        this.final_Time = GlobalTimer.score_Time;
        this.total_score = this.final_score + this.final_Time;

        this.HUD.SetActive(false);
        this.FinishUI.transform.Find("MusicBGStop").gameObject.SetActive(true);
        this.FinishUI.transform.Find("Background").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        this.FinishUI.transform.Find("Text - Level Complete").gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        this.FinishUI.transform.Find("Text - Collectibles").gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        this.FinishUI.transform.Find("Score").gameObject.SetActive(true);
        this.FinishUI.transform.Find("Score").GetComponent<Text>().text = "" + this.final_score;
        yield return new WaitForSeconds(1);
        this.FinishUI.transform.Find("Text - Time").gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        this.FinishUI.transform.Find("Time").gameObject.SetActive(true);
        this.FinishUI.transform.Find("Time").GetComponent<Text>().text = "" + this.final_Time;
        yield return new WaitForSeconds(0.5f);
        this.FinishUI.transform.Find("Line").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.FinishUI.transform.Find("Text - Total Score").gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        this.FinishUI.transform.Find("Total Score").gameObject.SetActive(true);
        this.FinishUI.transform.Find("Total Score").GetComponent<Text>().text = "" + this.total_score;
        yield return new WaitForSeconds(1);
        this.FinishUI.transform.Find("Main Menu").gameObject.SetActive(true);
        this.FinishUI.transform.Find("Main Menu").gameObject.transform.Find("Text").gameObject.SetActive(true);
        this.FinishUI.transform.Find("Star_1").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.FinishUI.transform.Find("Star_2").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.FinishUI.transform.Find("Star_3").gameObject.SetActive(true);

        this.activeUser = PlayerPrefs.GetString("User_Active");
        if (PlayerPrefs.GetInt(this.activeUser + "_Score") < this.total_score)
        {
            PlayerPrefs.SetInt(this.activeUser + "_Score", this.total_score);
        }

        PlayerPrefs.SetInt(this.activeUser + "_Collectibles", PlayerPrefs.GetInt(this.activeUser + "_Collectibles") + this.final_score);
    }
}
