using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeflectBullet : MonoBehaviour
{

    public GameObject playerProjectile;
    public Rigidbody2D playerProj;

    bool changeDir = false;
    bool range = false;

    float movementSpeed = 2000F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject boss2 = GameObject.Find("boss");
        bubbleShield bossScript = boss2.GetComponent<bubbleShield>();
        changeDir = bossScript.changeDirection;
        range = bossScript.isInRange;

        changeDir = bossScript.changeDirection;
        //Debug.Log(changeDir);

        if(changeDir == true)
        {
            //Debug.Log("Deflect projectile");
            //playerProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -movementSpeed * Time.fixedDeltaTime);

            //bossScript.changeDirection = false;
           
            // playerProjectile.velocity = (playerProjectile.velocity) * (-1);
        }

    }

}
