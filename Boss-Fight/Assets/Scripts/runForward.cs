using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runForward : MonoBehaviour
{
    int chargeDistance = 10;
    int chargeSpeed = 7;
    public Rigidbody2D theBoss;
    public Transform thePlayer;
    public Rigidbody2D player2;
    bool haveCollided = false;
    public Vector2 lastPos;
    public Vector2 position;
    bool inRange = false;
    int chargeCount = 0;
    int rangeDist = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, thePlayer.position) <= rangeDist)
        {
            inRange = true;
        }

        if (inRange == true && chargeCount == 0)
        {
            lastPos = GameObject.Find("player-placeholder").transform.position;
            position = gameObject.transform.position;
            chargeCount = 1;
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


