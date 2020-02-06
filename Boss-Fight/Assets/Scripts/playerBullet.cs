using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float direction = 3F;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            direction = 0F;
        }
        if (Input.GetKey("down"))
        {
            direction = 1F;
        }
        if (Input.GetKey("right"))
        {
            direction = 2F;
        }
        if (Input.GetKey("left"))
        {
            direction = 3F;
        }
        if (Input.GetKey("space"))
        {
            //Instantiate(playerProjectile);
        }

    }
}
