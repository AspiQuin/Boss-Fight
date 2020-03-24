using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Code was written by Erin - Ask me if you have questions
public class Login : MonoBehaviour
{

    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button PlayButton;
    public Button RegisterButton;
    
    
    // Start is called before the first frame update
    //Use this for initialization
    void Start()
    {
       PlayButton.onClick.AddListener(() => {
        StartCoroutine(Main.Instance.Databasetest.Login(UsernameInput.text, PasswordInput.text));
        });

        DontDestroyOnLoad(GameObject.Find("Main"));
        
        
        //Debug.Log(GameObject.Find("Main").GetComponent<databasetest>().loggedin);
    }

    public void RegisterClick()
    {
        SceneManager.LoadScene("RegisterScene");
        Destroy(GameObject.Find("Main"));
    }
    
    void Update(){
                            
        if (GameObject.Find("Main").GetComponent<databasetest>().loggedin == true)
        {

            SceneManager.LoadScene("MainMenu");
        }
    }

}