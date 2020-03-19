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
    public bool isInRange = false;
    public bool fired = false;
    public bool changeDirection = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("playerProjectile") != null)
        {
            //GameObject proj2 = GameObject.Find("playerProjectile");
            //playerBullet projScript = proj2.GetComponent<playerBullet>();

            //Debug.Log("exists");
            projectile = GameObject.FindWithTag("playerProjectile");

            // Check when projectile is in range 
            if (Vector2.Distance(boss.transform.position, projectile.transform.position) <= rangeDist)
            {
                isInRange = true;
            }
        }

        // Increase shield meter and stop once it is full
        if (shieldMeter >= 99.95f && isInRange == true && fired == false)
        {
            meterFull = true;
            fired = true;
            //projScript.direction = -5;
        }
        else if (meterFull == false)
        {
            shieldMeter = shieldMeter + 10f; // 0.1
            //Debug.Log(shieldMeter);
            changeDirection = false;
            fired = false;
        }

        if (fired == true)
        {
            Debug.Log("FIRED");
            changeDirection = true;
            fired = false;
        }
        meterFull = false;
        fired = false;

    }

    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject proj2 = GameObject.Find("playerProjectile");
        playerBullet projScript = proj2.GetComponent<playerBullet>();

        if (meterFull == true && isInRange == true)
        {
            Debug.Log("colllll");
            projScript.direction = (projScript.direction) * -1;
        }
    }
    */
}
