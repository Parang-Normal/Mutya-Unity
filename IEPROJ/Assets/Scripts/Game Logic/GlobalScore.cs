using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour
{
    public static int current_Score;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = "" + current_Score;
    }
}
