using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //BUTTONS
    public Image resumeButton;
    public Image restartButton;
    public Image playButton;
    public Image quitButton;

    void Update()
    {
        //PAUSE & RESUME
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Quit();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseResume();
            }
        }
    }

    //PAUSE & RESUME
    public void PauseResume()
    {
        if (Time.timeScale == 1)
        {
            CursorUnlock();
            Time.timeScale = 0;
            //SHOW PAUSE MENU AND BUTTONS
        }
        else
        {
            CursorLock();
            Time.timeScale = 1;
            //HIDE PAUSE MENU AND BUTTONS
        }
    }

    //FAILED SCREEN
    public void Failed()
    {
        CursorUnlock();
        Time.timeScale = 0;
        //SHOW MENU WITH "RESTART" OR "QUIT" BUTTONS
    }

    //PASSED SCREEN
    public void Passed()
    {
        CursorUnlock();
        Time.timeScale = 0;
        //LOAD NEXT AREA
    }

    //CURSOR LOCKING
    public void CursorUnlock()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void CursorLock()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //RESTART
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //QUIT
    public void Quit()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
