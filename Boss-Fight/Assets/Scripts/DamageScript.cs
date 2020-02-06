using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    //public Animator animator;
    public bool dead = false;


    float timer;
    float deathTime = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //check if object is considered dead
        if (Health < 0)
        {
            dead = true;
        }
        else
        {
            timer = 0;
        }
        //animator.SetBool("dead", dead);

        //remove from screen after a time
        if ((timer > deathTime) && dead)
        {
            gameObject.SetActive(false);
        }
    }

    //function called in other scripts to deal damage
    public void damageTaken(int dmg)
    {
        Health -= dmg;
    }
}
