﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        
        actionTimer += Time.deltaTime;

        if (Input.GetKey("up") && Input.GetKey("right"))
        {
            transform.Translate(normalizedSpeed*Time.deltaTime,normalizedSpeed*Time.deltaTime,0);
        }
        else if(Input.GetKey("down") && Input.GetKey("right"))
        {
            transform.Translate(normalizedSpeed*Time.deltaTime,-normalizedSpeed*Time.deltaTime,0);
        }
        else if(Input.GetKey("up") && Input.GetKey("left"))
        {
            transform.Translate(-normalizedSpeed*Time.deltaTime,normalizedSpeed*Time.deltaTime,0);
        }
        else if(Input.GetKey("down") && Input.GetKey("left"))
        {
            transform.Translate(-normalizedSpeed*Time.deltaTime,-normalizedSpeed*Time.deltaTime,0);
        }
        else
        {
            if (Input.GetKey("up"))
            {
                transform.Translate(0,moveSpeed * Time.deltaTime ,0);
            }
            if (Input.GetKey("down"))
            {
                transform.Translate(0,-moveSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey("right"))
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0,0);
            }
            if (Input.GetKey("left"))
            {
                transform.Translate(-moveSpeed * Time.deltaTime, 0,0);
            }
        }

        if (Input.GetKey("z") && canDash)
        {
                moveSpeed = 30F;
                normalizedSpeed = 21.21F;
                storedTime = actionTimer;
                canDash = false;
        }
        if (actionTimer > storedTime + 0.2)
        {
            moveSpeed = 10F;
            normalizedSpeed = 7.07F;
        }
        if (actionTimer > storedTime + 5)
        {
            actionTimer = 0;
            canDash = true;
        }


    }
}
