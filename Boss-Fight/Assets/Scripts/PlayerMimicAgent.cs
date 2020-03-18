using System;
using UnityEngine;
using System.Linq;
using MLAgents;
using UnityEngine.Serialization;
using Barracuda;

public class PlayerMimicAgent : Agent
{
    [FormerlySerializedAs("m_Area")]
    public BossFightArea area;
    public float timeBetweenDecisionsAtInference;
    float m_TimeSinceDecision;

    BehaviorParameters m_BehaviorParameters;
    public enum Team
    {
        Boss = 0,
        Player = 1
    }

    float timer;

    public Camera actionCam;

    [HideInInspector]
    public Team team;
    int m_PlayerIndex;

    public int showAction;
    public float showReward;
    public int showStep;

    public NNModel bossBrain;

    public NNModel playerBrain;

    int config=-1;

    BossFightSettings bossFightSettings;

    [Tooltip("Because we want an observation right before making a decision, we can force " +
        "a camera to render before making a decision. Place the agentCam here if using " +
        "RenderTexture as observations.")]
    public Camera renderCamera;

    [Tooltip("Selecting will turn on action masking. Note that a model trained with action " +
        "masking turned on may not behave optimally when action masking is turned off.")]
    public bool maskActions = true;

    const int k_NoAction = 0;  // do nothing!
    const int k_Up = 1;
    const int k_Down = 10;//for some reason 2 was not part of the vectorAction array output
    const int k_Left = 3;
    const int k_Right = 4;
    const int k_UpRight = 6;
    const int k_DownLeft = 7;
    const int k_UpLeft = 8;
    const int k_DownRight = 9;
    const int k_shoot = 5;

    public bool shoot = false;
    public bool charging = false;

    Vector2 moveRangeMin;

    Vector2 moveRangeMax;

    public PlayerMimicAgent m_agent;

    public Rigidbody2D agentRb;

    public bool inverse;

    Collider2D objectSize;

    int flip;

    public override void InitializeAgent()
    {
        base.InitializeAgent();
        m_BehaviorParameters = gameObject.GetComponent<BehaviorParameters>();
        //if (m_BehaviorParameters.m_TeamID == (int)Team.Boss)
        //{
        //    team = Team.Boss;
        //    //m_Transform = new Vector3(transform.position.x - 4f, .5f, transform.position.z);
        //}
        //else
        //{
        //    team = Team.Player;
        //    //m_Transform = new Vector3(transform.position.x + 4f, .5f, transform.position.z);
        //}
        //agentRb = GetComponent<Rigidbody2D>();
        bossFightSettings = FindObjectOfType<BossFightSettings>();
        ////agentRb. = 500;
        ///
        config = 1;

        objectSize = gameObject.GetComponent<Collider2D>();

        Vector3 bottomLeftWorldCoordinates = actionCam.ViewportToWorldPoint(Vector3.zero);
        Vector3 topRightWorldCoordinates = actionCam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        moveRangeMin = bottomLeftWorldCoordinates + objectSize.bounds.extents;
        moveRangeMax = topRightWorldCoordinates - objectSize.bounds.extents;

        var playerState = new Players
        {
            agentRb = agentRb,
            startingPos = transform.position,
            agentScript = this,
        };
        area.playerStates.Add(playerState);
        m_PlayerIndex = area.playerStates.IndexOf(playerState);
        playerState.playerIndex = m_PlayerIndex;

        if (inverse)
        {
            flip = -1;
        }
        else
        {
            flip = 1;
        }
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
        var positionY = (int)transform.position.y;
        var maxPositionX = area.transform.Find("background").transform.localPosition.x;
        var maxPositionY = area.transform.Find("background").transform.localPosition.y;



        if (positionX <= moveRangeMin.x)
        {
            actionMasker.SetActionMask(k_Left);
        }

        if (positionX >= moveRangeMax.x)
        {
            actionMasker.SetActionMask(k_Right); 
        }

        if (positionY <= moveRangeMin.y)
        {
            actionMasker.SetActionMask(k_Down);
        }

        if (positionY >= moveRangeMax.y)
        {
            actionMasker.SetActionMask(k_Up);
        }
    }

    // to be implemented by the developer
    public override void AgentAction(float[] vectorAction)
    {
        AddReward(1f/4000f * flip);
        var action = Mathf.FloorToInt(vectorAction[0]);

        //charging = false;

        //for(int i = 0; i < vectorAction.Length; i++)
        //{
        //    Debug.Log(gameObject.name + " " + vectorAction[i]);
        //}
            

        //if (action == 2)
        //{
        //    Debug.Log(action);
        //}
        showAction = action;
        

        var targetPos = transform.position;
        switch (action)
        {
            case k_NoAction:
                // do nothing
                break;
            case k_Right:
                transform.Translate(10f * Time.deltaTime, 0, 0f);
                if (!inverse)
                {
                    gameObject.GetComponent<AgentBullet>().agentInput = k_Right;
                }
                break;
            case k_Left:
                transform.Translate(-10f * Time.deltaTime, 0, 0f);
                if (!inverse)
                {
                    gameObject.GetComponent<AgentBullet>().agentInput = k_Left;
                }
                break;
            case k_Up:
                transform.Translate(0, 10f * Time.deltaTime, 0);
                if (!inverse)
                {
                    gameObject.GetComponent<AgentBullet>().agentInput = k_Up;
                }
                break;
            case k_Down:
                transform.Translate(0, -10f * Time.deltaTime, 0);
                if (!inverse)
                {
                    gameObject.GetComponent<AgentBullet>().agentInput = k_Down;
                }
                break;
            case 2:
                transform.Translate(0, -10f * Time.deltaTime, 0);
                if (!inverse)
                {
                    gameObject.GetComponent<AgentBullet>().agentInput = k_Down;
                }
                break;
            case k_UpRight:
                transform.Translate(7f * Time.deltaTime, 7f * Time.deltaTime, 0f); //+ new Vector3(10f, 0, 0f);
                break;
            case k_UpLeft:
                transform.Translate(-7f * Time.deltaTime, 7f * Time.deltaTime, 0f);// + new Vector3(-10f, 0, 0f);
                break;
            case k_DownRight:
                transform.Translate(7f * Time.deltaTime, -7f * Time.deltaTime, 0);// + new Vector3(0f, 0, 10f);
                break;
            case k_DownLeft:
                transform.Translate(-7f * Time.deltaTime, -7f * Time.deltaTime, 0);// + new Vector3(0f, 0, -10f
                break;
            case k_shoot:
                //Debug.Log(action);
                if (!inverse)
                {
                    //Debug.Log("test1");
                    gameObject.GetComponent<AgentBullet>().agentInput = k_shoot;
                }
                else
                {
                    //Debug.Log("test2");
                    charging = true;
                }
                //transform.Translate(0, -10f * Time.deltaTime, 0);// + new Vector3(0f, 0, -10f);
                //gameObject.GetComponent<AgentBullet>().agentInput = k_Down;
                break;
            default:
                Debug.Log(action);
                if (!inverse)
                {
                    //Debug.Log("test");
                    gameObject.GetComponent<AgentBullet>().agentInput = 0;
                }
                
                throw new ArgumentException("Invalid action value");
                
        }
        
        if (inverse)
        {
            //Debug.Log(action);
            //Debug.Log("boss");
            if (!gameObject.GetComponent<runForward>().enabled && charging)
            {
                gameObject.GetComponent<runForward>().enabled = true;
            }
        }
        

    }
    //private void Update()
    //{
    //    if (!gameObject.GetComponent<runForward>().enabled && shoot)
    //    {
    //        gameObject.GetComponent<runForward>().enabled = true;
    //    }
    //}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerProjectile")
        {
            
            if (inverse)
            {
                //Debug.Log("im hit");
                m_agent.AddReward(1f);
                AddReward(-1);
                gameObject.GetComponent<DamageScript>().damageTaken(10);
                Destroy(collision.gameObject);
            }
            




        //    //gameObject.GetComponent<bossMove>().enabled = true;
        }

        //Debug.Log("life");

        timer += Time.unscaledDeltaTime;
        if (collision.gameObject.tag == "Player" && inverse && timer >= 1.0f)
        {
            //Debug.Log("test");
            m_agent.AddReward(-1);
            AddReward(1f);
            timer = 0;
        }

        if (collision.gameObject.tag == "boss" && !inverse)
        {
            //m_agent.AddReward(1f);
            //AddReward(-1f);
        }


    }
    public override float[] Heuristic()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            return new float[] { k_Down };
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            return new float[] { k_UpRight };
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            return new float[] { k_UpLeft };
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            return new float[] { k_DownLeft };
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            return new float[] { k_DownRight };
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return new float[] { k_Right };
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            return new float[] { k_Up };
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return new float[] { k_Left };
        }
        
        
        if (Input.GetKey(KeyCode.Space))
        {
            return new float[] { k_shoot };
        }
        return new float[] { k_NoAction };
    }

    // to be implemented by the developer
    public override void AgentReset()
    {
        //Debug.Log("triple test");
        config = 1;
        area.AreaReset();
    }

    public void FixedUpdate()
    {
        WaitTimeInference();
        if (config != -1)
        {
            if (inverse)
            {
                //Debug.Log("test");
                //GiveModel("bossLearning", bossBrain);
            }
            else
            {
                
                GiveModel("playerLearning", playerBrain);
            }
            config = 1;
        }
        if (gameObject.GetComponent<DamageScript>().dead)
        {
            //Done();
            area.AgentDead();

        }
        if (GetCumulativeReward() <= -50f)
        {
            //Debug.Log("something is dead");
            //Done();
            area.AgentDead();

        }
        showStep = StepCount;
        showReward = GetCumulativeReward();
    }

    void WaitTimeInference()
    {
        if (renderCamera != null)
        {
            renderCamera.Render();
        }

        if (Academy.Instance.IsCommunicatorOn)
        {
            //if (inverse)
            //{
            //    Debug.Log("boss");
            //}
            //else
            //{
            //    Debug.Log("player");
            //}
            RequestDecision();
        }
        else
        {
            if (!charging)
            {
                //if(inverse)
                //{
                //    Debug.Log("boss");
                //}
                //else
                //{
                //    Debug.Log("player");
                //}
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
