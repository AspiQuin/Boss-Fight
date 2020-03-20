using System;
using UnityEngine;
using System.Linq;
using MLAgents;
using UnityEngine.Serialization;

public class BossFightAgent : Agent
{
    [FormerlySerializedAs("m_Area")]
    public BossFightArea area;
    public float timeBetweenDecisionsAtInference;
    float m_TimeSinceDecision;

    [Tooltip("Because we want an observation right before making a decision, we can force " +
        "a camera to render before making a decision. Place the agentCam here if using " +
        "RenderTexture as observations.")]
    public Camera renderCamera;

    [Tooltip("Selecting will turn on action masking. Note that a model trained with action " +
        "masking turned on may not behave optimally when action masking is turned off.")]
    public bool maskActions = true;

    const int k_NoAction = 0;  // do nothing!
    const int k_Up = 1;
    const int k_Down = 2;
    const int k_Left = 3;
    const int k_Right = 4;
    const int k_sprint = 5;

    public bool charging = false;

    public override void InitializeAgent()
    {
    }

    public override void CollectObservations(VectorSensor sensor, ActionMasker actionMasker)
    {
        // There are no numeric observations to collect as this environment uses visual
        // observations.

        // Mask the necessary actions if selected by the user.
        if (maskActions)
        {
            SetMask(actionMasker);
        }
    }

    /// <summary>
    /// Applies the mask for the agents action to disallow unnecessary actions.
    /// </summary>
    void SetMask(ActionMasker actionMasker)
    {
        // Prevents the agent from picking an action that would make it collide with a wall
        var positionX = (int)transform.position.x;
        var positionZ = (int)transform.position.z;
        var maxPosition = (int)Academy.Instance.FloatProperties.GetPropertyWithDefault("gridSize", 5f) - 1;

        if (positionX == 0)
        {
            actionMasker.SetActionMask(k_Left);
        }

        if (positionX == maxPosition)
        {
            actionMasker.SetActionMask(k_Right);
        }

        if (positionZ == 0)
        {
            actionMasker.SetActionMask(k_Down);
        }

        if (positionZ == maxPosition)
        {
            actionMasker.SetActionMask(k_Up);
        }
    }

    // to be implemented by the developer
    public override void AgentAction(float[] vectorAction)
    {
        AddReward(-0.01f);
        var action = Mathf.FloorToInt(vectorAction[0]);

        var targetPos = transform.position;
        switch (action)
        {
            case k_NoAction:
                // do nothing
                break;
            case k_Right:
                targetPos = transform.position + new Vector3(1f, 0, 0f);
                break;
            case k_Left:
                targetPos = transform.position + new Vector3(-1f, 0, 0f);
                break;
            case k_Up:
                targetPos = transform.position + new Vector3(0f, 0, 1f);
                break;
            case k_Down:
                targetPos = transform.position + new Vector3(0f, 0, -1f);
                break;
            case k_sprint:
                charging = true;
                break;
            default:
                throw new ArgumentException("Invalid action value");
        }
        if (gameObject.GetComponent<DamageScript>().dead)
        {
            Done();
            //Debug.Log("test");
        }
        if (!gameObject.GetComponent<runForward>().enabled && charging)
        {
            gameObject.GetComponent<runForward>().enabled = true;
        }

        //var hit = Physics.OverlapBox(
        //    targetPos, new Vector3(0.3f, 0.3f, 0.3f));
        //if (hit.Where(col => col.gameObject.CompareTag("wall")).ToArray().Length == 0)
        //{
        //    transform.position = targetPos;

        //    if (hit.Where(col => col.gameObject.CompareTag("goal")).ToArray().Length == 1)
        //    {
        //        SetReward(1f);
        //        Done();
        //    }
        //    else if (hit.Where(col => col.gameObject.CompareTag("pit")).ToArray().Length == 1)
        //    {
        //        SetReward(-1f);
        //        Done();
        //    }
        //}

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "playerProjectile")
        {
            SetReward(-1f);
        }
        if (collision.gameObject.tag == "Player")
        {
            SetReward(1f);
        }
        
    }
    public override float[] Heuristic()
    {
        if (Input.GetKey(KeyCode.D))
        {
            return new float[] { k_Right };
        }
        if (Input.GetKey(KeyCode.W))
        {
            return new float[] { k_Up };
        }
        if (Input.GetKey(KeyCode.A))
        {
            return new float[] { k_Left };
        }
        if (Input.GetKey(KeyCode.S))
        {
            return new float[] { k_Down };
        }
        return new float[] { k_NoAction };
    }

    // to be implemented by the developer
    public override void AgentReset()
    {
        //Debug.Log("resetArea");
        area.AreaReset();
    }

    public void FixedUpdate()
    {
        WaitTimeInference();
    }

    void WaitTimeInference()
    {
        if (renderCamera != null)
        {
            renderCamera.Render();
        }

        if (Academy.Instance.IsCommunicatorOn)
        {
            RequestDecision();
        }
        else
        {
            if (!charging)
            {
                if (m_TimeSinceDecision >= timeBetweenDecisionsAtInference)
                {
                    m_TimeSinceDecision = 0f;
                    RequestDecision();
                }
                else
                {
                    m_TimeSinceDecision += Time.fixedDeltaTime;
                }
            }
            
        }
    }
}
