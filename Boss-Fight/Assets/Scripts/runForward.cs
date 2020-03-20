using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runForward : MonoBehaviour
{
    int chargeDistance = 10;
    int chargeCount = 0;
    int rangeDist = 6;
    int chargeSpeed = 6;

    public Rigidbody2D theBoss;
    //public Rigidbody2D player2;

    public Transform thePlayer;

    bool haveCollided = false;
    bool inRange = false;

    public Vector2 lastPos;
    public Vector2 position;
    public Vector2 bossCurrPos;

    float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.fixedDeltaTime;
        // Check whether the player is within a certain range of the boss and sets inRange to true if they are
        if (Vector2.Distance(transform.position, thePlayer.position) <= rangeDist)
        {
            inRange = true;
            //gameObject.GetComponent<bossMove>().enabled = false;
        }
        else
        {
            inRange = false;
            gameObject.GetComponent<runForward>().enabled = false;

        }

        // This basically just gets the position of the player when they entered the range of the boss
        if (chargeCount == 0)
        {
            lastPos = thePlayer.position;
            position = gameObject.transform.position;
            
        }

        if (chargeCount == 1 && timer > 0.5)
        {
            lastPos = thePlayer.position;
            position = gameObject.transform.position;
            timer = 0;

        }

        if (inRange == true)
        {
            chargeCount = 1;
        }

        // Get bosses current position
        bossCurrPos = gameObject.transform.position;

        // Mathf.Approximately compares two floats to see if they are within a small value of each other (since comparing two float values using == can be inaccurate)
        if (Mathf.Approximately(lastPos.x, bossCurrPos.x))
        {
            chargeCount = 0;


        }

        tackleForward();

   

    }

    public void tackleForward()
    {
        if (Vector2.Distance(transform.position, thePlayer.position) <= chargeDistance && haveCollided == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, lastPos, chargeSpeed * Time.deltaTime);
            gameObject.GetComponent<bossMove>().enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //theBoss.velocity = Vector2.zero;
        //haveCollided = true;
        //chargeCount = 1;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        haveCollided = false;
    }
}


