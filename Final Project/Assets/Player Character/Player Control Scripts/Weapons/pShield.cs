using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pShield : MonoBehaviour
{
    //The shield is a defensive subweapon that can strike back if the block is timed well.
    //Pressing Shift when an attack hits does a Regal Guard, which damages nearby enemies. 
    //If the player just holds shift, however, they can take up to a certain amount of hits equal to their stamina before their guard is broken and they take damage.
    //One thing I might consider doing is making it so that you can take hits while blocking, then switch to Hammer and immediately charge it.

    //Components
    private CharacterController charCont;
    private playerController player;
    private Animator anim;
    private AnimatorStateInfo currentBaseState;

    //Variables
    public int stamina; //How many hits are you taking?
    public int blockDamage; //This will be made private once I make the shield change materials for each hit blocked.
    public string PassCharge; //Like with block damage, this will be made private. This is set when the shield meets the limits below, and is only pulled when the player switches to hammer.
    public int midShieldLimit; //Shield changes to this material once this limit is met
    private int finalShieldLimit; //See line above. When the shield is at this point, any more damage taken will break your guard.
    //Regal Guarding
    public bool regal;
    private float regalTime = 0.1f;

    //Shield parts
    public GameObject backShield;
    private Renderer backShieldR;
    //Block damage materials
    public Material zeroShieldMat;
    public Material midShieldMat;
    public Material fullShieldMat;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<playerController>();
        charCont = GetComponent<CharacterController>();
        backShieldR = backShield.GetComponent<Renderer>();
        //sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        finalShieldLimit = stamina - 1;
    }

    void Update()
    {
        if (Input.GetButton("Stance"))
        {
            anim.SetBool("Dodge", false);
            anim.SetBool("Shield", true);
            anim.SetBool("Hammer", false);
            anim.SetBool("Gauntlets", false);
            player.iFrame = true;
        }
        else
        {
            anim.SetBool("Dodge", false);
            anim.SetBool("Shield", false);
            anim.SetBool("Hammer", false);
            anim.SetBool("Gauntlets", false);
        }

        if (Input.GetButtonDown("Stance"))
        {
            regal = true;
            StartCoroutine("perfectTimer");
        }
    }

    //Shield Breaks
    void resetStamina()
    {
        blockDamage = 0;
        PassCharge = "Empty";
    }
    void midShield()
    {
        PassCharge = "Mid";
    }
    void fullShield()
    {
        PassCharge = "Full";
    }
    void shieldBreak()
    {
        resetStamina();
    }

    //Regal Guard
    IEnumerator perfectTimer()
    {
        yield return new WaitForSeconds(regalTime);
        regal = false;
    }
    public void regalGuard()
    {
        Debug.Log("Regal Guard!");
        StartCoroutine("regalOff");
        //Collider[] releaseSphere = Physics.OverlapSphere(regalCenter, regalRadius);
        //foreach (var enemy in regalSphere)
        {
            //enemy.gameObject.GetComponent<enemyScript>().parried();
        }


    }
    IEnumerator regalOff()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
