using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pGauntlets : MonoBehaviour
{
    //Components
    private CharacterController charCont;
    private playerController player;
    private Animator anim;
    private AnimatorStateInfo currentBaseState;

    //Gauntlet renders
    private Renderer lGauntlet;
    private Renderer rGauntlet;

    void Start()
    {
        //Get components
        anim = GetComponent<Animator>();
        player = GetComponent<playerController>();
        charCont = GetComponent<CharacterController>();
        //sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        
    }
}
