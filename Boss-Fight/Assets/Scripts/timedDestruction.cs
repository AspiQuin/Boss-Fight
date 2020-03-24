using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedDestruction : MonoBehaviour
{
    float timer;
    float actionTimer = 0.6f;
    bool deleteInst;
    bool destroyObj = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject boss2 = GameObject.Find("boss");
        bubbleShield bossScript = boss2.GetComponent<bubbleShield>();
        deleteInst = bossScript.delInst;

        timer += Time.fixedDeltaTime;
   
        if (timer > actionTimer && deleteInst == true)
        {
            Debug.Log("deleting inst");
            Destroy(gameObject);
        }
    }
}
