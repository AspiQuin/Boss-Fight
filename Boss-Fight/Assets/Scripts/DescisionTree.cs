using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescisionTree : MonoBehaviour
{
    //Decides if another choice is necessary 
    public bool makeChoice;

    //range the boss can make decisions based off of
    [Range(0, 20)]
    public float distanceSensor;

    //distance between boss and player
    float distanceDetector;
    
    //keeps track of runtime
    float timer;

    //controls rate the boss updates its thoughts
    [Range(0, 20)]
    public float actionUpdate;

    //1.0 sized vector pointing at the player
    Vector2 direction;

    Vector2 prevPlayerPos;
    Vector2 traveled;
    
    //player
    public GameObject player;

    //boss
    GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        //set boss object
        boss = gameObject;
        prevPlayerPos = player.transform.position;

        //Set initial information
        direction = new Vector2(player.transform.position.x - boss.transform.position.x, player.transform.position.y - boss.transform.position.y);
        distanceDetector = direction.sqrMagnitude;
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //update timer
        timer += Time.deltaTime;

        //check if the action timer has expired
        if (timer > actionUpdate)
        {
            timer = 0;
            //if the player is within a certain distance
            if (distanceDetector > distanceSensor)
            {
                //ForwardTackle()
            }
            //if the player is within another distance
            else if (distanceDetector < distanceSensor * 2)
            {
                //shoot or move
                if (makeChoice)
                {
                    //Move in the direction of player
                } else
                {
                    //shoot in the direction of the player
                }
                traveled = new Vector2(player.transform.position.x - prevPlayerPos.x, player.transform.position.y - prevPlayerPos.y);
                if (traveled.sqrMagnitude > 0.3)
                {
                    if (traveled.sqrMagnitude < 0.5)
                    {
                        makeChoice = false;
                    }
                    else
                    {
                        makeChoice = true;
                    }
                    prevPlayerPos = player.transform.position;
                }

            }
            else
            {
                //tackle forward
            }
           
        }

    }

}
