using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSrc;

    //UI SFX
    public AudioClip pauseOnSound;
    public AudioClip pauseOffSound;
    public AudioClip quitRestartSound;
    public AudioClip hoverOnSound;
    public AudioClip hoverOffSound;

    //PLAYER FOOTSTEPS
    public AudioClip footstepGrass;
    public AudioClip footstepDirt;
    public AudioClip footstepRock;
    public AudioClip footstepSnow;
    public AudioClip footstepSand;

    public void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            //FOOTSTEPS
            case "footstepGrass":
                audioSrc.volume = Random.Range(0.8f, 1.2f);
                audioSrc.pitch = Random.Range(0.8f, 1.2f);
                audioSrc.PlayOneShot(footstepGrass);
                break;
            case "footstepDirt":
                audioSrc.volume = Random.Range(0.8f, 1.2f);
                audioSrc.pitch = Random.Range(0.8f, 1.2f);
                audioSrc.PlayOneShot(footstepDirt);
                break;
            case "footstepRock":
                audioSrc.volume = Random.Range(0.8f, 1.2f);
                audioSrc.pitch = Random.Range(0.8f, 1.2f);
                audioSrc.PlayOneShot(footstepRock);
                break;
            case "footstepSnow":
                audioSrc.volume = Random.Range(0.8f, 1.2f);
                audioSrc.pitch = Random.Range(0.8f, 1.2f);
                audioSrc.PlayOneShot(footstepSnow);
                break;
            case "footstepSand":
                audioSrc.volume = Random.Range(0.8f, 1.2f);
                audioSrc.pitch = Random.Range(0.8f, 1.2f);
                audioSrc.PlayOneShot(footstepSand);
                break;

            //UI SFX
            case "PauseOn":
                audioSrc.PlayOneShot(pauseOnSound);
                break;
            case "PauseOff":
                audioSrc.PlayOneShot(pauseOffSound);
                break;
            case "QuitRestart":
                audioSrc.PlayOneShot(quitRestartSound);
                break;
        }
    }

    public void HoverOn()
    {
        audioSrc.PlayOneShot(hoverOnSound);
    }
    public void HoverOff()
    {
        audioSrc.PlayOneShot(hoverOffSound);
    }

}
