using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepWithinCameraView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Keep boss within camera view
        // WorldToViewportPoint - Transforms position from viewport space into world space
        Vector3 bossPosition = Camera.main.WorldToViewportPoint(transform.position);

        // Mathf.Clamp01 - Clamps the given value between the given minimum float and maximum float values
        bossPosition.x = Mathf.Clamp01(bossPosition.x);
        bossPosition.y = Mathf.Clamp01(bossPosition.y);
        transform.position = Camera.main.ViewportToWorldPoint(bossPosition);
    }
}
