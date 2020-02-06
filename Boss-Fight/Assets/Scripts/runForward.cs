using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runForward : MonoBehaviour
{
    int chargeDistance = 10;
    int chargeCount = 0;
    int rangeDist = 5;
    int chargeSpeed = 6;

    public Rigidbody2D theBoss;
    public Rigidbody2D player2;

    public Transform thePlayer;

    bool haveCollided = false;
    bool inRange = false;

    public Vector2 lastPos;
    public Vector2 position;
    public Vector2 bossCurrPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check whether the player is within a certain range of the boss and sets inRange to true if they are
        if (Vector2.Distance(transform.position, thePlayer.position) <= rangeDist)
        {
            inRange = true;
        }

        // This basically just gets the position of the player when they entered the range of the boss
        if (inRange == true && chargeCount == 0)
        {
            lastPos = GameObject.Find("player-placeholder").transform.position;
            position = gameObject.transform.position;
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

        // Freeze the rotation on the boss and player to prevent from the tipping over when they collide
        theBoss.freezeRotation = true;
        player2.freezeRotation = true;

    }

    void tackleForward()
    {
        if (Vector2.Distance(transform.position, thePlayer.position) <= chargeDistance && haveCollided == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, lastPos, chargeSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        theBoss.velocity = Vector2.zero;
        haveCollided = true;
        chargeCount = 1;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        haveCollided = false;
    }
}


