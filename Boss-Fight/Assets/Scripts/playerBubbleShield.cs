using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBubbleShield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject shield;
    static double totalShieldCharge = 10;
    public double shieldChargeNow = 10;
    bool shieldBurnt = false;
    // Update is called once per frame
    void Update()
    {
        //If the shield charge drops to 0, the shield is burnt, and cannot be used.
        if (shieldChargeNow <= 0)
        {
            shieldBurnt = true;
        }
        //If the shield is fully charged, it can be used again.
        if (shieldChargeNow > 10)
        {
            shieldChargeNow = 10;
            shieldBurnt = false;
        }

        //Checks for input and shild burnness.
        if (Input.GetKey("v") && (shieldBurnt==false))
        {
            shield.SetActive(true);
            shieldChargeNow -= 2*Time.deltaTime;
        }
        else
        {
            shield.SetActive(false);
            
            if (shieldChargeNow < totalShieldCharge)
            {
                //burnt recharge
                if (shieldBurnt)
                {
                    shieldChargeNow += 0.5*Time.deltaTime;
                }
                //normal recharge
                else
                {
                    shieldChargeNow += Time.deltaTime;
                }
            }
            
        }
    }
}
