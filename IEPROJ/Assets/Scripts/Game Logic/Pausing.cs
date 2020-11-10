using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;

    private int isPaused = -1;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.isPaused *= -1;

            if (this.isPaused == 1)
            {
                this.Pause();
            }
            else if (this.isPaused == -1)
            {
                this.Resume();
            }
        }
    }

    public void Pause()
    {
        this.isPaused = 1;
        this.PauseMenu.SetActive(true);
        UnityEngine.Time.timeScale = 0.0f;
    }
    public void Resume()
    {
        this.isPaused = -1;
        this.PauseMenu.SetActive(false);
        UnityEngine.Time.timeScale = 1.0f;
    }
}
