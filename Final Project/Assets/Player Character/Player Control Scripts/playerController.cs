using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Things this script needs
//1. Jumping
//2. Attack Strings (mostly done in animator)
//3. Weapon Enabling and Disabling
    //Dodge
    //Shield
    //Hammer
    //Gauntlets

public class playerController : MonoBehaviour
{
    //Components
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController charCont;
    private Animator anim;
    private AnimatorStateInfo currentBaseState;
    private playerHealth health;
    public Collider weaponBox;
    //public SoundManager sound;
    //Subweapon Components
    private pDodge dodge;
    private pShield shield;
    private pHammer hammer;
    private pGauntlets gauntlets;

    //Control variables
    public float speed = 10f;
    public float jumpSpeed;
    public bool isGrounded;
    public float gravity = 20f;
    public float pushSpeed = 4f;
    public float tSmoothTime = 0.2f;
    float tSmoothVelocity;
    Transform cameraT;

    //Invulnerability Variables
    public float iTimer = 3f; //This is how long you are invulnerable for.
    public bool iFrame; //This is whether or not you have invincibility. I made it public cause then its easier to tell when iFrames are active. 
                        //Can be toggled in editor to make it easier to test enemy AI without dying.

    //Weapon renderers
    public MeshRenderer shieldR;
    public MeshRenderer hammerR;
    public MeshRenderer hammerHandR;
    public MeshRenderer rGauntletR; //Right Gauntlet
    public MeshRenderer lGauntletR; //Left Gauntlet

    //Animator states
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int runState = Animator.StringToHash("Base Layer.Run");
    static int landState = Animator.StringToHash("Base Layer.Land");


    void Start()
    {
        //Get component variables
        charCont = GetComponent<CharacterController>();
        cameraT = Camera.main.transform;
        anim = GetComponent<Animator>(); //Finds the animator
        //sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        //Subweapon Variables
        dodge = GetComponent<pDodge>();
        shield = GetComponent<pShield>();
        hammer = GetComponent<pHammer>();
        gauntlets = GetComponent<pGauntlets>();
        equipDodge();
    }

    void Update()
    {
        playerMove();
        Grounding();

        if (Input.GetButton("Jump") && isGrounded)
        {
            Jump();
        }

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

    //Movement
    void playerMove()
    {
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

        //Right now player can only move in idle/run. I still need to integrate jumping. 
        if (currentBaseState.nameHash == idleState | currentBaseState.nameHash == runState)
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 InputDir = input.normalized;

            if (InputDir != Vector2.zero)
            {
                float tRotate = Mathf.Atan2(InputDir.x, InputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, tRotate, ref tSmoothVelocity, tSmoothTime);
            }

            if (input != Vector2.zero)
            {
                charCont.Move(transform.forward * speed * Time.deltaTime);
            }

            anim.SetFloat("Run", Mathf.Abs(input.x) + Mathf.Abs(input.y));

            //Disable animation triggers
            anim.ResetTrigger("Heavy");
            anim.ResetTrigger("Light");
            //anim.ResetTrigger("Jump");
            //OnWeapon triggers
            anim.ResetTrigger("OnDodge");
            anim.ResetTrigger("OnShield");
            anim.ResetTrigger("OnHammer");
            anim.ResetTrigger("OnGauntlets");

            //Hide subweapons. 
            //shieldHandR.enabled = false;
            //hammerHandR.enabled = false;
        }
        //If landing, turn off jump
        if (currentBaseState.nameHash == landState)
        {
            anim.ResetTrigger("Jump");
        }
        //This is where we apply gravity. Gravity is multipled by Time.deltaTime twice - here and below where we actually move the character controller. This is because gravity accelerates, and is defined in terms of meters per second squared. The squared part is why we multiply by deltaTime twice.  
        moveDirection.y -= gravity * Time.deltaTime;

        charCont.Move(moveDirection * Time.deltaTime);  //Actually moves the GameObject with the character controller on it

        if (Input.GetButtonDown("Fire1"))
        {
            lightAttack();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            heavyAttack();
        }

        //Below helps with jumping
    }
    void Jump()
    {
        anim.SetTrigger("Jump");
        moveDirection.y = jumpSpeed;
    }
    void Grounding()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if(Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
            anim.SetBool("Fall", false);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("Fall", true);
        }
    }

    //Base Attacks
    void lightAttack()
    {

    }
    void heavyAttack()
    {

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

    //The following are placeholders used b/c the animations want them for some reason and they would fill up the debug log. 
    //I might do stuff w these later
    public void FootR()
    {
        
    }
    public void FootL()
    {
        
    }
    public void Land()
    {

    }


}