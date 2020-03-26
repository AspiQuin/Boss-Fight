using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneShift : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   public void TitleScreen()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ControlsScreen()
    {
        SceneManager.LoadScene("Controls");
    }
    
        
    public void CreditsScreen()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void GameStart()
    {
        SceneManager.LoadScene("GameView");
    }
    
    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
    
    public void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
