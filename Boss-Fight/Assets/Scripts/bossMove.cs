using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMove : MonoBehaviour
{
    public Rigidbody2D my_rb;
    public Rigidbody2D player1;
    public Transform player;
    float speed = 3.0f;
    int minDistance = 0;
    bool haveCollided = false;

    // int maxDistance = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Freeze the rotation on the boss and player to prevent from the tipping over when they collide
        my_rb.freezeRotation = true;
        player1.freezeRotation = true;

        my_rb.velocity = Vector2.zero;

        // Boss follows player
        if (Vector2.Distance(transform.position, player.position) >= minDistance && haveCollided == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        my_rb.velocity = Vector2.zero;
        haveCollided = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        haveCollided = false;
    }
}
