﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class velocity : MonoBehaviour
{
    public float direction = 0F;

    public void setDirection(float input)
    {
        direction = input;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float movementSpeed = 0.5F;

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case 0:
            transform.Translate(0,movementSpeed,0);
            break;
            case 1:
            transform.Translate(0,-movementSpeed,0);
            break;
            case 2:
            transform.Translate(movementSpeed,0,0);
            break;
            case 3:
            transform.Translate(-movementSpeed,0,0);
            break;
        }
    }
}
