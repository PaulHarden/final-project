using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image pauseMenu;
    public Image resumeButton;
    public Image restartButton;
    public Image playButton;
    public Image quitButton;

    public void Start()
    {
        pauseMenu.enabled = false;
        resumeButton.enabled = false;
        restartButton.enabled = false;
        quitButton.enabled = false;
    }

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
            pauseMenu.enabled = true;
            resumeButton.enabled = true;
            restartButton.enabled = true;
            quitButton.enabled = true;
        }
        else
        {
            CursorLock();
            Time.timeScale = 1;
            //HIDE PAUSE MENU AND BUTTONS
            pauseMenu.enabled = false;
            resumeButton.enabled = false;
            restartButton.enabled = false;
            quitButton.enabled = false;
        }
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
        Time.timeScale = 1;
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

    //LOADING SCENES
    public void forestPlay()
    {
        SceneManager.LoadScene("Forest");
    }
    public void tundraPlay()
    {
        SceneManager.LoadScene("Tundra");
    }
    public void desertPlay()
    {
        SceneManager.LoadScene("Desert");
    }
}
