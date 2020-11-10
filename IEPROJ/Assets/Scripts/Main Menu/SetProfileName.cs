using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetProfileName : MonoBehaviour
{
    private string activeUser;

    // Update is called once per frame
    void Update()
    {
        this.activeUser = PlayerPrefs.GetString("User_Active");
        this.GetComponent<Text>().text = "" + this.activeUser;
    }
}
