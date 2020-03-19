using MLAgents;
using System.Collections.Generic;
using UnityEngine;
public class Players
{
    public int playerIndex;
    public Rigidbody2D agentRb;
    public Vector2 startingPos;
    public PlayerMimicAgent agentScript;
}


public class BossFightArea : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> actorObjs;



    [HideInInspector]
    public int[] players;
    public List<Players> playerStates = new List<Players>();


    public GameObject trueAgent;
    public GameObject mimicAgent;

    private IFloatProperties m_ResetParameters;

    private Camera m_AgentCam;

    //public Text cumulativeRewardText;

    public GameObject goalPref;
    public GameObject pitPref;
    private GameObject[] m_Objects;

    private GameObject m_Plane;
    //GameObject m_Sn;
    //GameObject m_Ss;
    //GameObject m_Se;
    //GameObject m_Sw;

    private Vector3 m_InitialPosition;

    public void Start()
    {
        m_ResetParameters = Academy.Instance.FloatProperties;

        m_Objects = new[] { goalPref, pitPref };

        //trueAgent = pitPref;

        //mimicAgent = goalPref;

        m_AgentCam = transform.Find("agentCam").GetComponent<Camera>();

        actorObjs = new List<GameObject>();

        //var sceneTransform = transform.Find("background");

        m_Plane = transform.Find("background").gameObject;

        m_InitialPosition = transform.position;
        //AreaReset();
        //Time.timeScale;
    }

    private void Update()
    {
        // Update the cumulative reward text
        //cumulativeRewardText.text = trueAgent.GetCumulativeReward().ToString("0.00");
    }

    public void AgentDead()
    {
        //Debug.Log(playerStates.Count);

        foreach (var ps in playerStates)
        {
            //if (ps.agentScript.team == scoredTeam)
            //{
            //    ps.agentScript.AddReward(-1);
            //}
            //else
            //{
            //    ps.agentScript.AddReward(1);
            //}
            
            ps.agentScript.Done();  //all agents need to be reset
        }
    }
    public float[] randomPlayerSpawn(Vector2 center)
    {
        //Destroy(transform.Find("player-placeholder").gameObject);
        //Destroy(transform.Find("player-placeholder(clone)").gameObject);

        float backg_sizeX = transform.Find("background").gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        float backg_sizeY = transform.Find("background").gameObject.GetComponent<SpriteRenderer>().bounds.size.y;

        float xRand = Random.Range(-backg_sizeX / 2, 0);
        float yRand = Random.Range(-backg_sizeY / 2, backg_sizeY / 2);

        float[] playerSpawn = new float[2];
        playerSpawn[0] = xRand;
        playerSpawn[1] = yRand;
        return playerSpawn;
    }

    public float[] randomBossSpawn(Vector2 center)
    {
        //Destroy(transform.Find("boss").gameObject);
        //Destroy(transform.Find("boss(clone)").gameObject);

        //m_Plane = transform.Find("background").gameObject;
        float backg_sizeX = transform.Find("background").gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        float backg_sizeY = transform.Find("background").gameObject.GetComponent<SpriteRenderer>().bounds.size.y;

        //Debug.Log("X: " + backg_sizeX + " Y: " + backg_sizeY);

        float xRand = Random.Range(center.x, center.x + backg_sizeX / 2);
        float yRand = Random.Range(center.y - backg_sizeY / 2, center.y + backg_sizeY / 2);

        float[] bossSpawn = new float[2];
        bossSpawn[0] = xRand;
        bossSpawn[1] = yRand;
        return bossSpawn;
    }

    public void SetEnvironment()
    {
        //Debug.Log(Time.timeScale);
        //transform.position = m_InitialPosition * (m_ResetParameters.GetPropertyWithDefault("gridSize", 5f) + 1);
        var playersList = new List<int>();

        playersList.Add(1);

        playersList.Add(0);

        players = playersList.ToArray();

        trueAgent.GetComponent<DamageScript>().Health = 100;
        mimicAgent.GetComponent<DamageScript>().Health = 100;

        trueAgent.GetComponent<DamageScript>().dead = false;
        mimicAgent.GetComponent<DamageScript>().dead = false;

        mimicAgent.GetComponent<AgentBullet>().setSpawn();

        //var gridSize = (int)m_ResetParameters.GetPropertyWithDefault("gridSize", 5f);
        //m_Plane.transform.localScale = new Vector3(gridSize / 10.0f, 1f, gridSize / 10.0f);
        //m_Plane.transform.localPosition = new Vector3((gridSize - 1) / 2f, -0.5f, (gridSize - 1) / 2f);
        //m_Sn.transform.localScale = new Vector3(1, 1, gridSize + 2);
        //m_Ss.transform.localScale = new Vector3(1, 1, gridSize + 2);
        //m_Sn.transform.localPosition = new Vector3((gridSize - 1) / 2f, 0.0f, gridSize);
        //m_Ss.transform.localPosition = new Vector3((gridSize - 1) / 2f, 0.0f, -1);
        //m_Se.transform.localScale = new Vector3(1, 1, gridSize + 2);
        //m_Sw.transform.localScale = new Vector3(1, 1, gridSize + 2);
        //m_Se.transform.localPosition = new Vector3(gridSize, 0.0f, (gridSize - 1) / 2f);
        //m_Sw.transform.localPosition = new Vector3(-1, 0.0f, (gridSize - 1) / 2f);

        //m_AgentCam.orthographicSize = (gridSize) / 2f;
        //m_AgentCam.transform.localPosition = new Vector3((gridSize - 1) / 2f, gridSize + 1f, (gridSize - 1) / 2f);
    }

    public void AreaReset()
    {
        //foreach (var actor in actorObjs)
        //{
        //    Destroy(actor);
        //}
        //Destroy(trueAgent);
        //Destroy(mimicAgent);

        SetEnvironment();

        actorObjs.Clear();

        //var numbers = new HashSet<int>();
        //while (numbers.Count < players.Length + 1)
        //{
        //    numbers.Add(Random.Range(0, gridSize * gridSize));
        //}
        //var numbersA = Enumerable.ToArray(numbers);

        float[] playerPosition = randomPlayerSpawn(transform.position);
        float[] bossPosition = randomBossSpawn(transform.position);
        //Debug.Log("test1");

        //for (var i = 0; i < players.Length; i++)
        //{
        //mimicAgent = Instantiate(goalPref, transform);
        //trueAgent = Instantiate(pitPref, transform);
        //Debug.Log("test2");

        //actorObj1.transform.SetParent(transform);
        //actorObj2.transform.SetParent(transform);
        //Debug.Log("test3");

        mimicAgent.transform.localPosition = new Vector3(playerPosition[0], playerPosition[1], 0);
        trueAgent.transform.localPosition = new Vector3(bossPosition[0], bossPosition[1], 0);
        //Debug.Log("test4");

        //actorObjs.Add(actorObj1);
        //actorObjs.Add(actorObj2);
        //}

        //mimicAgent.gameObject.transform.localPosition = new Vector3(playerPosition[0], playerPosition[1], 0);
        //Debug.Log("this is going to work");
        //actorObjs.Add(actorObj);
        //var xA = (numbersA[players.Length]) / gridSize;
        //var yA = (numbersA[players.Length]) % gridSize;

        //trueAgent.gameObject.transform.position = new Vector3(bossPosition[0], bossPosition[1], 0);
    }
}