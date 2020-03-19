using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleShield : MonoBehaviour
{
    public GameObject projectile;
    public GameObject boss;
    
    float shieldMeter = 0;
    int shieldTime = 7;
    int rangeDist = 2;

    bool meterFull = false;
    bool isInRange = false;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("playerProjectile") != null)
        {
            //Debug.Log("exists");
            projectile = GameObject.FindWithTag("playerProjectile");

            // Check when projectile is in range 
            if (Vector2.Distance(boss.transform.position, projectile.transform.position) <= rangeDist)
            {
                isInRange = true;            }
        }

        // Increase shield meter and stop once it is full
        if (shieldMeter >= 99.95f && isInRange == true)
        {
            meterFull = true;
        }
        else if (meterFull == false)
        {
            shieldMeter = shieldMeter + 0.1f;
            //Debug.Log(shieldMeter);
        }

    }
}
