using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    //Components
    private playerController player;
    private Animator anim;
    private CharacterController charCont;

    //Health variables
    public float maxHealth = 10f; //This is the max value we use.
    public float pHealth; //This is the player's current HP. I will make this private once we have a health bar.

    void Start()
    {
        pHealth = maxHealth;
        anim = GetComponent<Animator>(); 
        player = GetComponent<playerController>();
    }

    public void PlayerDamage()
    {
        pHealth -= 1;

        if (pHealth <= 0)
        {
            gameOver();
        }
        else
        {
            anim.SetTrigger("Damage");
            charCont.Move(new Vector3(0, 0, 0));
        }
    }
    public void gameOver()
    {
        anim.SetTrigger("Death");
        //StartCoroutine("LoadGameOver");
        //Destroy(playerHealthBar.gameObject);
    }
}
