using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Code was written by Erin - Ask me if you have questions
public class Leaderboard : MonoBehaviour
{

    public Text leaderboardText;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Main.Instance.Databasetest.GetLeaderboard());
       // leaderboardText.text = s;
    }

    // Update is called once per frame
    void Update()
    {
        string test = GameObject.Find("Main").GetComponent<databasetest>().s;
        leaderboardText.text = test;
    }
    
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}