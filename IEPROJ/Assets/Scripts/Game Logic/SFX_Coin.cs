using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Coin : MonoBehaviour
{
    public static bool play = false;

    private void Update()
    {
        if (play)
        {
            this.GetComponent<AudioSource>().Play();
            play = false;   
        }
    }
}
