using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDamageScript : MonoBehaviour
{

    public int testScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "playerProjectile")
        {
            gameObject.GetComponent<DamageScript>().damageTaken(10);
            Destroy(collide.gameObject);
            gameObject.GetComponent<bossMove>().enabled = true;
            
            //Erin here making a very base score calculation to develop the leaderboard
            testScore += 200;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
