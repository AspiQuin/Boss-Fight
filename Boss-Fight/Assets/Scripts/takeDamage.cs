﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{

    float timer;
    public float damageTimer = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timer > damageTimer)
        {
            if (collision.gameObject.tag == "boss")
            {

                gameObject.GetComponent<DamageScript>().damageTaken(10);
            }
            timer = 0;
        }
        

    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "bossProjectile")
        {
            gameObject.GetComponent<DamageScript>().damageTaken(10);
            Destroy(collide.gameObject);
            
        }
    }
}
