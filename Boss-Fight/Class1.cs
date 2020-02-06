using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepWithinCameraView : MonoBehaviour
{
    Collider2D objectSize;

    Vector2 center;

    Vector2 minimum;

    Vector2 maximum;

    Vector2 verticalBound;

    Vector2 minBound;

    // Start is called before the first frame update
    void Start()
    {
        objectSize = gameObject.GetComponent<Collider2D>();
        center = objectSize.bounds.center;
        minimum = objectSize.bounds.min;
        maximum = objectSize.bounds.max;

        /*
        Debug.Log("center" + center);
        Debug.Log("minimum" + minimum);
        Debug.Log("maximum" + maximum);
        */

        //horizontalBound = objectSize.bounds.extents;//new Vector2(minimum.y - center.y, maximum.y - center.y);
        verticalBound = objectSize.bounds.extents; // new Vector2(minimum.x - center.x, maximum.x - center.x);
        verticalBound = verticalBound.normalized;

        //Debug.Log(horizontalBound);
        Debug.Log(verticalBound);

    }

    // Update is called once per frame
    void Update()
    {
        // Keep boss within camera view
        // WorldToViewportPoint - Transforms position from viewport space into world space
        Vector3 bossPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 bounding = Camera.main.WorldToViewportPoint(verticalBound);

        // Mathf.Clamp01 - Clamps the given value between the given minimum float and maximum float values
        if (bossPosition.x < bounding.x)
        {
            bossPosition.x = Mathf.Clamp01(bossPosition.x + Mathf.Clamp01(bounding.x));
        }
        else if (bossPosition.x > 1 - Mathf.Clamp01(bounding.x))
        {
            bossPosition.x = Mathf.Clamp01(bossPosition.x - Mathf.Clamp01(bounding.x));
        }

        bossPosition.y = Mathf.Clamp01(bossPosition.y);
        transform.position = Camera.main.ViewportToWorldPoint(bossPosition);

        /*
        //Keep the player from going off screen
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, movementRangeMin.x, movementRangeMax.x);
        newPosition.y = Mathf.Clamp(newPosition.y, movementRangeMin.y, movementRangeMax.y);
        transform.Translate(newPosition - transform.position);
        */
    }
}
