using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pManager : MonoBehaviour
{
    //Components
    private CharacterController charCont;
    private Animator anim;
    private AnimatorStateInfo currentBaseState;
    //Subweapon Components
    private pDodge dodge;
    private pShield shield;
    private pHammer hammer;
    private pGauntlets gauntlets;

    //Weapon renderers
    public MeshRenderer shieldR;
    public MeshRenderer hammerR;
    public MeshRenderer hammerHandR;
    public MeshRenderer rGauntletR; //Right Gauntlet
    public MeshRenderer lGauntletR; //Left Gauntlet

    void Start()
    {
        charCont = GetComponent<CharacterController>();
        anim = GetComponent<Animator>(); //Finds the animator
        //Subweapon Variables
        dodge = GetComponent<pDodge>();
        shield = GetComponent<pShield>();
        hammer = GetComponent<pHammer>();
        gauntlets = GetComponent<pGauntlets>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Weapon1"))
        {
            equipDodge();
        }
        if (Input.GetButtonDown("Weapon2"))
        {
            equipShield();
        }
        if (Input.GetButtonDown("Weapon3"))
        {
            equipHammer();
        }
        if (Input.GetButtonDown("Weapon4"))
        {
            equipGauntlets();
        }
    }

    //Equipping
    void equipDodge()
    {
        //Animation Trigger
        anim.SetTrigger("OnDodge");
        //Turn on/off weapons
        dodge.enabled = true;
        shield.enabled = false;
        hammer.enabled = false;
        gauntlets.enabled = false;
        //Render Weapons
        shieldR.enabled = false;
        hammerR.enabled = false;
        hammerHandR.enabled = false;
        rGauntletR.enabled = false;
        lGauntletR.enabled = false;
    }
    void equipShield()
    {
        //Animation Trigger
        anim.SetTrigger("OnShield");
        //Turn on/off modes
        dodge.enabled = false;
        shield.enabled = true;
        hammer.enabled = false;
        gauntlets.enabled = false;
        //Render Weapons
        shieldR.enabled = true;
        hammerR.enabled = false;
        rGauntletR.enabled = false;
        lGauntletR.enabled = false;


    }
    void equipHammer()
    {
        //Animation Trigger
        anim.SetTrigger("OnHammer");
        //Turn on/off modes
        dodge.enabled = false;
        shield.enabled = false;
        hammer.enabled = true;
        gauntlets.enabled = false;
        //Render Weapons
        shieldR.enabled = false;
        hammerR.enabled = true;
        rGauntletR.enabled = false;
        lGauntletR.enabled = false;

        //Convert blockDamage to hammer charge
        hammer.passCharge(shield.PassCharge);
    }
    void equipGauntlets()
    {
        //Animation Trigger
        anim.SetTrigger("OnGauntlets");
        //Turn on/off modes
        dodge.enabled = false;
        shield.enabled = false;
        hammer.enabled = false;
        gauntlets.enabled = true;
        //Render Weapons
        shieldR.enabled = false;
        hammerR.enabled = false;
        hammerHandR.enabled = false;
        rGauntletR.enabled = true;
        lGauntletR.enabled = true;
    }
    //Weapons can be changed in and out at any point, and change what holding shift does. Check the weapon's script for more info on that weapon.
    //When switching weapons, the following steps happen in order.
    //1a. The player enters a short animation only if they are idling. The animation is purely aesthetic and can be interrupted with any other animation. 
    //1b. If the player's not idling, the animation is skipped.
    //2. The weapon's script is turned on, while all the other weapons are turned off.
    //3. The weapon is rendered, while the others are unrendered. 
    //There are two gauntlets, which is why there are two gauntletR variables. 
    //There is also hand hammer rendering because I don't want to actually move the hammer off the back.
}
