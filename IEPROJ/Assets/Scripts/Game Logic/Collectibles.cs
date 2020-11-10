using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] int scoreAmount;

    private void OnTriggerEnter()
    {
        SFX_Coin.play = true;
        GlobalScore.current_Score += this.scoreAmount;
        Destroy(this.gameObject);
    }
}
