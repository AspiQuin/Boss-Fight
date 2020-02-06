using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{

    public GameObject playerProjectile;

    float actionTimer;

    // Start is called before the first frame update
    void Start()
    {
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
        }
        if (Input.GetKey("down"))
        {
            direction = 1F;
        }
        if (Input.GetKey("right"))
        {
            direction = 2F;
        }
        if (Input.GetKey("left"))
        {
            direction = 3F;
        }
        if (Input.GetKey("space"))
        {
            if (actionTimer > 2)
            {
                GameObject projectileClone;
                projectileClone = Instantiate(playerProjectile, transform.position, Quaternion.identity);
                projectileClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(600,0));
                actionTimer = 0;
            }
            
        }

    }
}
