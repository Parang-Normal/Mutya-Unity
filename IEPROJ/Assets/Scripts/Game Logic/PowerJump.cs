using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerJump : MonoBehaviour
{
    [SerializeField] GameObject PowerJumpFill;

    public static bool PowerJumpReady = false;

    // Update is called once per frame
    void Update()
    {
        if (this.PowerJumpFill.GetComponent<Image>().fillAmount == 1)
        {
            PowerJumpReady = true;
        }
        else
        {

            this.PowerJumpFill.GetComponent<Image>().fillAmount += Time.deltaTime / 10;
        }
           
    }
}
