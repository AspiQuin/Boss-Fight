using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{

    public GameObject playerProjectile;

    float actionTimer;

    Vector3 spawnPos;

    Vector2 playerSize;

    // Start is called before the first frame update
    void Start()
    {
        playerSize = gameObject.GetComponent<Collider2D>().bounds.extents;
        //Instantiate(playerProjectile, transform.position, Quaternion.identity);
    }

    float direction = 3F;
    // Update is called once per frame
    void Update()
    {
        actionTimer += Time.deltaTime;
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
        if (Input.GetKey("space"))
        {
            if (actionTimer > 2)
            {
                GameObject projectileClone;
                projectileClone = Instantiate(playerProjectile, spawnPos, Quaternion.identity);
                //projectileClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(600,0));
                actionTimer = 0;
            }
            
        }

    }
}
