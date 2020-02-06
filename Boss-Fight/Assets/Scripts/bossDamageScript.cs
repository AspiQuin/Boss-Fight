using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDamageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "playerProjectile")
        {
            gameObject.getComponent<DamageScript>().damageTaken(10);
            destroy(collide.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
