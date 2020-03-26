using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public GameObject bossProjectile;

    float actionTimer;

    Vector3 spawnPos;

    Vector2 playerSize;

    float movementSpeed = 400F;

    float direction = 3F;

    public bool fire = false;

    // Start is called before the first frame update
    void Start()
    {
        playerSize = gameObject.GetComponent<Collider2D>().bounds.extents;
        spawnPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - (playerSize.y * 2));
        //Instantiate(playerProjectile, transform.position, Quaternion.identity);
    }

    public void setSpawn(int fireDirection)
    {
        if (fireDirection == 1)
        {
            direction = 0F;
            spawnPos = new Vector2(transform.position.x, transform.position.y + (playerSize.y * 2));
        }
        if (fireDirection == 2)
        {
            direction = 1F;
            spawnPos = new Vector2(transform.position.x, transform.position.y - (playerSize.y * 2));
        }
        if (fireDirection == 3)
        {
            direction = 2F;
            spawnPos = new Vector2(transform.position.x + (playerSize.x * 2), transform.position.y);
        }
        if (fireDirection == 4)
        {
            direction = 3F;
            spawnPos = new Vector2(transform.position.x - (playerSize.x * 2), transform.position.y);

        }
    }

    
    // Update is called once per frame
    void Update()
    {
        actionTimer += Time.fixedDeltaTime;
        if (fire)
        {

            if (actionTimer > 0.2)
            {
                //Debug.Log(spawnPos);
                GameObject projectileClone;
                projectileClone = Instantiate(bossProjectile, spawnPos, Quaternion.identity);
                //velocity.direction = direction;

                switch (direction)
                {
                    case 0:
                        projectileClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, movementSpeed * Time.fixedDeltaTime);
                        break;
                    case 1:
                        projectileClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -movementSpeed * Time.fixedDeltaTime);
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
            fire = false;

        }

    }
}
