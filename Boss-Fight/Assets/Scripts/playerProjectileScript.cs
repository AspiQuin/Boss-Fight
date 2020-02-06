using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public class CollisionGameObjectExample : MonoBehaviour
{
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "boss")
        {
            Destroy(gameObject);
        }

    }
}
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
