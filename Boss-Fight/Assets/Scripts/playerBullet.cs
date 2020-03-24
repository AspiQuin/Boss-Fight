using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{

    public GameObject playerProjectile;
    public Animator animator;

    float actionTimer;

    Vector3 spawnPos;

    Vector2 playerSize;

    float movementSpeed = 2000F;

    // Start is called before the first frame update
    void Start()
    {
        playerSize = gameObject.GetComponent<Collider2D>().bounds.extents;
        spawnPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - (playerSize.y * 2));
        //Instantiate(playerProjectile, transform.position, Quaternion.identity);
    }

    public void setSpawn()
    {
        spawnPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - (playerSize.y * 2));
    }

    float direction = 3F;
    // Update is called once per frame
    void Update()
    {
        actionTimer += Time.fixedDeltaTime;
        if (Input.GetKey("up"))
        {
            direction = 0F;
            spawnPos = new Vector2(transform.position.x, transform.position.y + (playerSize.y * 2));
        }
        if (Input.GetKey("down"))
        {
            direction = 1F;
            spawnPos = new Vector2(transform.position.x, transform.position.y - (playerSize.y * 2));
        }
        if (Input.GetKey("right"))
        {
            direction = 2F;
            spawnPos = new Vector2(transform.position.x + (playerSize.x * 2), transform.position.y);
        }
        if (Input.GetKey("left"))
        {
            direction = 3F;
            spawnPos = new Vector2(transform.position.x - (playerSize.x * 2), transform.position.y);

        }
        if (Input.GetKeyDown("x"))
        {
            
            if (actionTimer > 0.2)
            {
                //Activate animation for 
                animator.SetTrigger("Shoot");
                //Debug.Log(spawnPos);
                GameObject projectileClone;
                projectileClone = Instantiate(playerProjectile, spawnPos, Quaternion.identity);
                //velocity.direction = direction;

                switch (direction)
                {
                    case 0:
                        projectileClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, movementSpeed * Time.fixedDeltaTime);
                        break;
                    case 1:
                        projectileClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -movementSpeed  * Time.fixedDeltaTime);
                        break;
                    case 2:
                        projectileClone.GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed * Time.fixedDeltaTime, 0);
                        break;
                    case 3:
                        projectileClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed * Time.fixedDeltaTime, 0);
                        break;
                }
                actionTimer = 0;
            }

            }

    }
}
