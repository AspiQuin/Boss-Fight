using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public static Main Instance;

    public databasetest Databasetest;
    
    // Start is called before the first frame update
    public void Start()
    {
        Instance = this;
        Databasetest = GetComponent<databasetest>();
    }

}
