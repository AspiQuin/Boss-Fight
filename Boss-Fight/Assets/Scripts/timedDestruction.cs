using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedDestruction : MonoBehaviour
{
    float timer;
    float actionTimer = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.fixedDeltaTime;
        if (timer > actionTimer)
        {
            Destroy(gameObject);
        }
    }
}
