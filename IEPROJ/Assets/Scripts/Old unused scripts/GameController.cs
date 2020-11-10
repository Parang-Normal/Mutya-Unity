using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        this.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.InputListen();
        this.Action();
    }

    private void InputListen()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!this.isPaused)
            {
                this.isPaused = true;
            }
            else if (this.isPaused)
            {
                this.isPaused = false;
            }
        }
        
    }

    private void Action()
    {
        if (this.isPaused)
        {
            this.Pause_Game();
        }
        else if (!this.isPaused)
        {
            this.Resume_Game();
        }
    }

    public void Quit_Game()
    {
        Debug.Log("Quitted");
        Application.Quit();
    }

    public void Resume_Game()
    {
        this.isPaused = false;
        UnityEngine.Time.timeScale = 1.0f;
        this.PauseMenu.SetActive(false);
    }

    public void Pause_Game()
    {
        this.isPaused = true;
        UnityEngine.Time.timeScale = 0.0f;
        this.PauseMenu.SetActive(true);
    }
}
