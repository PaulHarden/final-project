using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pHammer : MonoBehaviour
{
    //The hammer is a charge weapon. Holding down shift begins to charge the weapon. 
    //There are 3 levels of charge (None, Mid, Full), that decide which swing attack you do when you press light attack. 
    //Pressing heavy attack while charging does something I haven't decided yet/
    //Burst lets off an explosion that deals more damage depending on the charge level. You can't Burst with no charge. 
    //Bash is a shoulder bash. When bashing, your charge is paused and saved so long as you hold down shift. 

    //Components
    private CharacterController charCont;
    private playerController player;
    private Animator anim;
    private AnimatorStateInfo currentBaseState;

    //Variables
    public float currentCharge; //This will be made private once I make the hammer change materials for each charge level.
    public float midChargeLimit; //Once the charge reaches this value, it changes color.
    public float fullChargeLimit; //Look at the line above.

    //Hammer renders
    public Renderer backHammer;
    public Renderer handHammer;
    //Charge level materials
    public Material noChargeMat;
    public Material midChargeMat;
    public Material fullChargeMat;

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

    void noneSwing()
    {

    }
    void midSwing()
    {

    }
    void fullSwing()
    {

    }

    public void passCharge(string PassCharge)
    {
        switch (PassCharge)
        {
            case "Empty":
                currentCharge = 0f;
                break;
            case "Mid":
                currentCharge = midChargeLimit;
                break;
            case "Full":
                currentCharge = fullChargeLimit;
                break;
        }
    }
}
