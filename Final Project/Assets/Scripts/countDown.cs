using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class countDown : MonoBehaviour
{
    public float currentTime = 0f; //tracks the current time on the timer
    float startingTime = 10f; //defines the time the timer will start at after being defined by the scene

    public float forestTime = 10f; 
    public float tundraTime = 20f; 
    public float desertTime = 30f;
    //these variables store the starting time for each scene made editable in the inspector window for easy tuning/balancing

    public UIController uiController;
    public Text clock;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene(); //stores a reference to the current scene
        string sceneName = currentScene.name;
        if(sceneName == "Forest")
        {
            startingTime = forestTime;
            Debug.Log(forestTime);
        }
        else if (sceneName == "Desert")
        {
            startingTime = desertTime;
            Debug.Log(desertTime);
        }
        else if (sceneName == "Tundra")
        {
            startingTime = tundraTime;
            Debug.Log(tundraTime);
        }
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        /*
         * TODO update the text each frame to reflect the players current time
         * countdownText.text = currentTime.ToString(0);
         */
        if(currentTime <= 0)
        {
            currentTime = 0;
            uiController.Failed();
            //outofTime();
        }
        Debug.Log(currentTime);

        //DISPLAYING THE TIME LEFT
        clock.text = currentTime.ToString("0");
    }
    /*void outofTime()
    {
        //TODO whatever exactly happens when the palyer runs out of time. 
        //Likely a "game over" text made active as well as restart and quit buttons with appropriate button events
    }*/
}
