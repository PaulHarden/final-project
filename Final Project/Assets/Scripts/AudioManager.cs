using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip sound;

    public void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "sound":
                audioSrc.PlayOneShot(sound);
                break;
        }
    }
}
