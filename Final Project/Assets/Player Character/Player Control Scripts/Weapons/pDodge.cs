using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pDodge : MonoBehaviour
{
    //The dodge is your base subweapon. When you hold shift in idle, you enter a defensive position, ready to do a sliding dodge.
    //The sliding dodge is done by holding shift, then pressing a key in WASD.
    //You can also dodge in the middle of attacks, ending the combo. Dodging through an enemy like this can damage them.

    //Components
    private CharacterController charCont;
    private playerController player;
    private Animator anim;
    private AnimatorStateInfo currentBaseState;

    //Dodge Renders????

    void Start()
    {
        //Get components
        anim = GetComponent<Animator>();
        player = GetComponent<playerController>();
        charCont = GetComponent<CharacterController>();
        //sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
