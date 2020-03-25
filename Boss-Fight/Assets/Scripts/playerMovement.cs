using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //Animator
    public Animator animator;
    //Speed of the player character
    float moveSpeed = 10F;
    float normalizedSpeed = 7.07F;
    //Timer for dash cooldown variables
    float actionTimer;
    float storedTime = 0F;
    bool canDash = true;

    // Update is called once per frame
    void Update()
    {
        //reset animation checks
        animator.SetBool("Walk", false);
        //animator.SetBool("Run", false);
        //Run speed timer
        actionTimer += Time.deltaTime;
        //Detects direction and moves in that direction.
        if (Input.GetKey("up") && Input.GetKey("right"))
        {
            transform.Translate(normalizedSpeed*Time.deltaTime,normalizedSpeed*Time.deltaTime,0);
            animator.SetBool("Walk", true);
        }
        else if(Input.GetKey("down") && Input.GetKey("right"))
        {
            transform.Translate(normalizedSpeed*Time.deltaTime,-normalizedSpeed*Time.deltaTime,0);
            animator.SetBool("Walk", true);
        }
        else if(Input.GetKey("up") && Input.GetKey("left"))
        {
            transform.Translate(-normalizedSpeed*Time.deltaTime,normalizedSpeed*Time.deltaTime,0);
            animator.SetBool("Walk", true);
        }
        else if(Input.GetKey("down") && Input.GetKey("left"))
        {
            transform.Translate(-normalizedSpeed*Time.deltaTime,-normalizedSpeed*Time.deltaTime,0);
            animator.SetBool("Walk", true);
        }
        else
        {
            if (Input.GetKey("up"))
            {
                transform.Translate(0,moveSpeed * Time.deltaTime ,0);
                animator.SetBool("Walk", true);
            }
            if (Input.GetKey("down"))
            {
                transform.Translate(0,-moveSpeed * Time.deltaTime, 0);
                animator.SetBool("Walk", true);
            }
            if (Input.GetKey("right"))
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0,0);
                animator.SetBool("Walk", true);
            }
            if (Input.GetKey("left"))
            {
                transform.Translate(-moveSpeed * Time.deltaTime, 0,0);
                animator.SetBool("Walk", true);
            }
        }

        if (Input.GetKey("z") && canDash)
        {
                //Animation key
                animator.SetBool("Run", true);
                //Increasing movement speed.
                moveSpeed = 30F;
                normalizedSpeed = 21.21F;
                storedTime = actionTimer;
                canDash = false;
        }
        if (actionTimer > storedTime + 0.2)
        {
            moveSpeed = 10F;
            normalizedSpeed = 7.07F;
            animator.SetBool("Run", false);
        }
        if (actionTimer > storedTime + 5)
        {
            actionTimer = 0;
            canDash = true;
        }


    }
}
