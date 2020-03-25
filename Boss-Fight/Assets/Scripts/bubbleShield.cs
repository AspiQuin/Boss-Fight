using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleShield : MonoBehaviour
{
    public GameObject projectile;
    public GameObject boss;

    public BoxCollider2D boxCol;

    public Rigidbody2D rb;
    
    float shieldMeter = 0;
    float movementSpeed = 500f;
    int shieldTime = 7;
    int rangeDist = 2;

    bool meterFull = false;
    bool runFixed = false;
    public bool showTxt = false;
    public bool isInRange = false;
    public bool fired = false;
    public bool changeDirection = false;
    public bool delInst = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("playerProjectile") != null)
        {
            projectile = GameObject.FindWithTag("playerProjectile");
            rb = projectile.GetComponent<Rigidbody2D>();

            // Check when projectile is in range 
            if (Vector2.Distance(boss.transform.position, projectile.transform.position) <= rangeDist)
            {
                isInRange = true;
                //Debug.Log("proj in range");
            }
        }

        if(shieldMeter >= 99.95f)
        {
            showTxt = true;
            //boxCol.enabled = true;
        }
        else if(shieldMeter <= 99.94f)
        {
            showTxt = false;
        }

        // Increase shield meter and stop once it is full
        if (shieldMeter >= 99.95f && isInRange == true && fired == false)
        {
            projectile.GetComponent<BoxCollider2D>().enabled = true;
            meterFull = true;
            fired = true;
        }
        else if (meterFull == false)
        {
            shieldMeter = shieldMeter + 0.4f; // 0.1
           
            //Debug.Log(shieldMeter);
            //changeDirection = false;
            fired = false;
        }

        if (fired == true)
        {
            //Debug.Log("in range and fired");
            changeDirection = true;
            fired = false;
            
        }

        if (changeDirection == true)
        {
            //Debug.Log("Proj collided with boss");
            delInst = false;
            runFixed = true;
            shieldMeter = 0;

        }
        else
        {
            delInst = true;
        }

        meterFull = false;
        fired = false;
        isInRange = false;
        changeDirection = false;

    }

    void FixedUpdate()
    {
        if(runFixed == true)
        {
            Vector3 v3Velocity = rb.velocity;
            float velx = v3Velocity.x;
            float vely = v3Velocity.y + 10f;
            //Debug.Log(velx);
            //transform.position = new Vector3(vel, 0.0f, 0.0f);
            //rb.AddForce(transform.up * 1);
            
            rb.AddForce(new Vector2(velx * -3, vely * -1), ForceMode2D.Impulse);
            //boxCol.enabled = false;
            projectile.GetComponent<BoxCollider2D>().enabled = false;
            runFixed = false;
        }
    }



}
