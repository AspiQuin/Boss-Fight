using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projCollRange : MonoBehaviour
{

    // NOT BEING USED - I'm just keeping for now in case I need tis code for later




    public GameObject theBoss;
    public GameObject thePlayer;
    public GameObject collDetect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.parent = theBoss.transform;
        collDetect.transform.position = theBoss.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("col");
        if (collision.gameObject.tag == "playerProjectile")
        {
            Debug.Log("coll = proj");
        }
    }
}
