using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSystem : MonoBehaviour
{
    public static int listCount;

    private string user_Name;
    private int user_Score;
    private int user_Collectibles;

    private void OnDisable()
    {
        this.setPlayerList();
        this.user_Name = this.transform.Find("Dropdown").transform.Find("Label").GetComponent<Text>().text;
        PlayerPrefs.SetString("User_Active", this.user_Name);
    }

    // Update is called once per frame
    void Update()
    {
        this.user_Name = this.transform.Find("Dropdown").transform.Find("Label").GetComponent<Text>().text;

        this.user_Score = PlayerPrefs.GetInt(this.user_Name + "_Score");
        this.user_Collectibles = PlayerPrefs.GetInt(this.user_Name + "_Collectibles");

        this.transform.Find("Text - Highscore").GetComponent<Text>().text = "Highscore: " + this.user_Score;
        this.transform.Find("Text - Collectibles").GetComponent<Text>().text = "Collectibles: " + this.user_Collectibles;
    }

    private void setPlayerList()
    {
        listCount = -1;
        Dropdown dropdown = this.transform.Find("Dropdown").GetComponent<Dropdown>();
        PlayerPrefs.SetInt("User_Count", dropdown.options.Count);


        foreach (Dropdown.OptionData option in dropdown.options)
        {
            listCount++;
            PlayerPrefs.SetString("User_List_" + listCount, option.text);
            //Debug.Log(PlayerPrefs.GetString("User_List_" + listCount) + " | " + listCount + " | " + ("" + option.text));
        }
    }

    public void save()
    {
        PlayerPrefs.SetString("User_Active", this.user_Name);
        PlayerPrefs.SetString(this.user_Name, this.user_Name);
    }

    public void reset()
    {
        PlayerPrefs.SetInt(this.user_Name + "_Score", 0);
        PlayerPrefs.SetInt(this.user_Name + "_Collectibles", 0);
    }
}
