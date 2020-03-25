using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject[] mus = GameObject.FindGameObjectsWithTag("music");
        if (mus.Length > 1)
            Destroy (mus[0]);
    }
       
}
