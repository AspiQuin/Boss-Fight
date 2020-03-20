using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepWithinCameraView : MonoBehaviour
{

    public Camera actionCam;

    Collider2D objectSize;

    Vector3 bounding;

    Vector2 center;

    Vector2 minimum;

    Vector2 maximum;

    Vector2 moveRangeMin;

    Vector2 moveRangeMax;

    bool isOverX;
    bool isUnderX;
    bool isOverY;
    bool isUnderY;


    // Start is called before the first frame update
    void Start()
    {
        objectSize = gameObject.GetComponent<Collider2D>();
        center = objectSize.bounds.center;
        minimum = objectSize.bounds.min;
        maximum = objectSize.bounds.max;

        Vector3 bottomLeftWorldCoordinates = actionCam.ViewportToWorldPoint(Vector3.zero);
        Vector3 topRightWorldCoordinates = actionCam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        moveRangeMin = bottomLeftWorldCoordinates + objectSize.bounds.extents;
        moveRangeMax = topRightWorldCoordinates - objectSize.bounds.extents;

        bounding = objectSize.bounds.extents;

        minimum.x = minimum.x - center.x;
        minimum.y = minimum.y - center.y;
        minimum.x = minimum.x - center.x;

        //Debug.Log("center" + center);
        //Debug.Log("minimum" + minimum);

        //Debug.Log("maximum" + maximum);

    }

    // Update is called once per frame
    void Update()
    {
        // Keep boss within camera view
        // WorldToViewportPoint - Transforms position from viewport space into world space
        Vector3 bossPosition = actionCam.WorldToViewportPoint(transform.position);
        //Debug.Log(transform.position);
        //Debug.Log(bossPosition);
        /*
        if(bossPosition.x > 0.99)
        {
            isOverX = true;
        }
        else
        {
            isOverX = false;
        }
        
        if (bossPosition.x < 0)
        {
            isUnderX = true;
        }
        else
        {
            isUnderX = false;
        }

        if(bossPosition.y > 1)
        {
            isOverY = true;
        }
        else
        {
            isOverY = false;
        }
        
        if (bossPosition.y < 0)
        {
            isUnderY = true;
        }
        else
        {
            isUnderY = false;
        }

        // Mathf.Clamp01 - Clamps the given value between the given minimum float and maximum float values
        bossPosition.x = Mathf.Clamp01(bossPosition.x);
        bossPosition.y = Mathf.Clamp01(bossPosition.y);


        transform.position = Camera.main.ViewportToWorldPoint(bossPosition);
        if (isUnderX)
        {
            transform.position = new Vector3(transform.position.x + bounding.x, transform.position.y, transform.position.z);
        } 
        else if (isOverX)
        {
            transform.position = new Vector3(transform.position.x - bounding.x, transform.position.y, transform.position.z);
        }
        if (isUnderY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + bounding.y, transform.position.z);
        }
        else if (isOverY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - bounding.y, transform.position.z);
        }
        */
    }
    public void LateUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, moveRangeMin.x, moveRangeMax.x);
        newPosition.y = Mathf.Clamp(newPosition.y, moveRangeMin.y, moveRangeMax.y);
        transform.Translate(newPosition - transform.position);
    }
}
