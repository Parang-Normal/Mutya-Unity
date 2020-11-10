using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWorld : MonoBehaviour
{
    public void refreshWorld()
    {
        GlobalScore.current_Score = 0;
        GlobalTimer.elapsed_Time = 0;
    }
}
