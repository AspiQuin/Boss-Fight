using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] finishObjects;
    public GameObject[] winObjects;
    void Start()
    {
        hideFinished();
        hideWin();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("boss").GetComponent<DamageScript>().dead == true)
        {
            showWin();
            Time.timeScale = 0;
        }

        if (GameObject.FindWithTag("Player").GetComponent<DamageScript>().dead == true)
        {
            showFinished();
            Time.timeScale = 0;
        }
    }

    //reload the scene
    //public void Reload()
    //{
       // Scene scene = SceneManager.GetActiveScene();
       // SceneManager.LoadScene(scene.name);
    //}
    //hides the win objects on start
    public void hideWin()
    {
        foreach(GameObject g in winObjects)
        {
            g.SetActive(false);
        }
    }

    //hides the game over objects on start
    public void hideFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(false);
        }
    }

    //shows the win screen on enemy death
    public void showWin()
    {
        foreach (GameObject g in winObjects)
        {
            g.SetActive(true);
        }
    }

    //shows the game over objects on death
    public void showFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(true);
        }
    }
    
    
}
