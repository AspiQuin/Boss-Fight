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

    Vector2 bulletVector;

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
        bulletVector = new Vector2(player.transform.position.x - boss.transform.position.x, player.transform.position.y - boss.transform.position.y);


    }

    // Update is called once per frame
    void Update()
    {
        //update timer
        timer += Time.fixedDeltaTime;

        //set boss bullet variables
        bulletVector.x = player.transform.position.x - boss.transform.position.x;
        bulletVector.y = player.transform.position.y - boss.transform.position.y;

        //set the initial boss bullet position
        GetComponent<BossBullet>().setSpawn(4);
        if (Mathf.Abs(bulletVector.y) < 1 && bulletVector.x < 0)
        {
            GetComponent<BossBullet>().setSpawn(4);
            //Debug.Log("Bullet X: " + bulletVector.x + " Bullet Y: " + bulletVector.y);
            makeChoice = false;
        }
        if (Mathf.Abs(bulletVector.y) < 1 && bulletVector.x > 0)
        {
            GetComponent<BossBullet>().setSpawn(3);
            //Debug.Log("Bullet X: " + bulletVector.x + " Bullet Y: " + bulletVector.y);
            makeChoice = false;
        }
        if (Mathf.Abs(bulletVector.x) < 1 && bulletVector.y < 0)
        {
            GetComponent<BossBullet>().setSpawn(2);
            //Debug.Log("Bullet X: " + bulletVector.x + " Bullet Y: " + bulletVector.y);
            makeChoice = false;
        }
        if (Mathf.Abs(bulletVector.x) < 1 && bulletVector.y > 0)
        {
            GetComponent<BossBullet>().setSpawn(1);
            //Debug.Log("Bullet X: " + bulletVector.x + " Bullet Y: " + bulletVector.y);
            makeChoice = false;
        }

        //Debug.Log("Bullet X: " + bulletVector.x + " Bullet Y: " + bulletVector.y);
        //check if the action timer has expired
        if (timer > actionUpdate)
        {           
            //GetComponent<BossBullet>().fire = true;
            if (!gameObject.GetComponent<bossMove>().enabled)
            {
                //gameObject.GetComponent<bossMove>().enabled = true;
                //Debug.Log("test");
            }
            timer = 0;
            //if the player is within a certain distance
            if (distanceDetector > distanceSensor)
            {
                //gameObject.GetComponent<bossMove>().enabled = false;

                gameObject.GetComponent<runForward>().enabled = true;
            }
            //if the player is within another distance

            //shoot or move
            if (makeChoice)
            {
                gameObject.GetComponent<bossMove>().enabled = true;
                //Move in the direction of player
            } else
            {
                gameObject.GetComponent<runForward>().enabled = false;
                gameObject.GetComponent<bossMove>().enabled = false;
                //shoot in the direction of the player
                GetComponent<BossBullet>().fire = true;
                makeChoice = true;
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

            
            else
            {
                gameObject.GetComponent<bossMove>().enabled = false;

                //tackle forward
            }
           
        }

    }

}
