using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Code was written by Erin - Ask me if you have questions
public class Register : MonoBehaviour
{

    public InputField UsernameInput;
    public InputField PasswordInput;
    public InputField ScreennameInput;
    public InputField PasswordInput2;
    public Button RegisterButton;
    
    // Start is called before the first frame update
    //Use this for initialization
    void Start()
    {
       RegisterButton.onClick.AddListener(() => {
       StartCoroutine(Main.Instance.Databasetest.RegisterUser(UsernameInput.text, PasswordInput.text, PasswordInput2.text, ScreennameInput.text));
       });
    }
    
    void Update(){
                            
    if (GameObject.Find("Main").GetComponent<databasetest>().loggedin == true)
    {
        SceneManager.LoadScene("MainMenu");
    }
    }

}
