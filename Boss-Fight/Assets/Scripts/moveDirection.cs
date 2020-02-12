using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDirection : MonoBehaviour
{
    //bool faceLeft;

    Vector2 prevPos;
    // Start is called before the first frame update
    void Start()
    {
        //faceLeft = gameObject.GetComponent<SpriteRenderer>().flipX;
        prevPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (prevPos.x < gameObject.transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
