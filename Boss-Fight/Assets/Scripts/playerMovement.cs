using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Speed of the player character
    const float moveSpeed = 0.2F;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.Translate(0,moveSpeed,0);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(0,-moveSpeed,0);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(moveSpeed,0,0);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(-moveSpeed,0,0);
        }
    }
}
