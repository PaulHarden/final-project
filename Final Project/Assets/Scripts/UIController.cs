using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public playerHealth playerHealth;
    public AudioManager audioManager;
    public countDown levelTimer;
    public Text pausedText;
    public Text failedText;
    public Text passedText;
    public Image pauseMenu;
    public Image resumeButton;
    public Image restartButton;
    public Image playButton;
    public Image quitButton;
    public Slider healthBar;
    public bool inProgress;

    public void Start()
    {
        inProgress = true;
        Time.timeScale = 1;
        pausedText.enabled = false;
        failedText.enabled = false;
        passedText.enabled = false;
        pauseMenu.enabled = false;
        resumeButton.enabled = false;
        restartButton.enabled = false;
        quitButton.enabled = false;
    }

    void Update()
    {
        //UPDATING HEALTHBAR
        healthBar.value = playerHealth.pHealth;

        if (inProgress)
        {
            //PAUSE & RESUME
            if (SceneManager.GetActiveScene().name == "MainMenu")
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
    }

    //FAILING
    public void Failed()
    {
        CursorUnlock();
        Time.timeScale = 0;
        audioManager.PlaySound("QuitRestart");
        inProgress = false;
        pauseMenu.enabled = true;
        failedText.enabled = true;
        restartButton.enabled = true;
        quitButton.enabled = true;
    }


    //PAUSE & RESUME
    public void PauseResume()
    {
        if (inProgress)
        {
            if (Time.timeScale == 1)
            {
                CursorUnlock();
                Time.timeScale = 0;
                audioManager.PlaySound("PauseOn");
                pausedText.enabled = true;
                pauseMenu.enabled = true;
                resumeButton.enabled = true;
                restartButton.enabled = true;
                quitButton.enabled = true;
            }
            else
            {
                CursorLock();
                Time.timeScale = 1;
                audioManager.PlaySound("PauseOff");
                pausedText.enabled = false;
                pauseMenu.enabled = false;
                resumeButton.enabled = false;
                restartButton.enabled = false;
                quitButton.enabled = false;
            }
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
        audioManager.PlaySound("QuitRestart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //QUIT
    public void Quit()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            audioManager.PlaySound("QuitRestart");
            Application.Quit();
        }
        else
        {
            audioManager.PlaySound("QuitRestart");
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
