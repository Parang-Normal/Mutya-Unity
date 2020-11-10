using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] GameObject UISystem;

    private GameObject GameOverUI;
    private GameObject HUD;

    private void Start()
    {
        this.GameOverUI = this.UISystem.transform.Find("GameOverUI").gameObject;
        this.HUD = this.UISystem.transform.Find("HUD").gameObject;
    }

    public void OnTriggerEnter()
    {
        SFX_Lose.play = true;
        this.HUD.SetActive(false);
        this.GameOverUI.SetActive(true);
    }
}
