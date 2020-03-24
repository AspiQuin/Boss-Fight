using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//Code was written by Erin - Ask me if you have questions
public class databasetest : MonoBehaviour
{

    public string s;
    public string result;
    public bool loggedin = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetDate());
        //StartCoroutine(GetUsers());
       // StartCoroutine(Login("unitytest", "12345"));
        //StartCoroutine(RegisterUser("unitytest","12345","unitytester"));
    }
    
    public IEnumerator GetDate()
    {
        using(UnityWebRequest www = UnityWebRequest.Get("http://ugrad.bitdegree.ca/~erinwaldram/testgetdate.php")) {
            yield return www.Send();
            
            if (www.isNetworkError || www.isHttpError) {
                //Debug.Log(www.error);
            }
            else {
            //Show the time results as text
                //Debug.Log(www.downloadHandler.text);
            
            //Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
            }
        
        }
    
    }
    
    public IEnumerator GetUsers()
    {
        using(UnityWebRequest www = UnityWebRequest.Get("http://ugrad.bitdegree.ca/~erinwaldram/unitydbtest.php")) {
            yield return www.Send();
            
            if (www.isNetworkError || www.isHttpError) {
                //Debug.Log(www.error);
            }
            else {
            //Show the time results as text
                //Debug.Log(www.downloadHandler.text);
            
            
            //Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
            }
        
        }
    
    }
    
    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPassword", password);
        
        using (UnityWebRequest www = UnityWebRequest.Post("http://ugrad.bitdegree.ca/~erinwaldram/Login.php", form))
        {
        
            yield return www.SendWebRequest();
            
            if (www.isNetworkError || www.isHttpError) 
            {
                //Debug.Log(www.error);
            }
            else 
            {
                result = www.downloadHandler.text;
                //Debug.Log(result);
                if (result == username)
                {
                    //Debug.Log("LOGIN");
                    loggedin = true;
                    
                }
            }
        }
    
    }
    
    public IEnumerator RegisterUser(string username, string password, string password2, string screenname)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPassword", password);
        form.AddField("loginPassword2", password2);
        form.AddField("loginScreen", screenname);

        
        using (UnityWebRequest www = UnityWebRequest.Post("http://ugrad.bitdegree.ca/~erinwaldram/RegisterUser.php", form))
        {
        
            yield return www.SendWebRequest();
            
            if (www.isNetworkError || www.isHttpError) 
            {
                //Debug.Log(www.error);
            }
            else 
            {
                result = www.downloadHandler.text;
                //Debug.Log(result);
                if (result == username)
                {
                    //Debug.Log("LOGIN");
                    loggedin = true;
                    
                }
                
            }
        }
    
    }
    
    public IEnumerator ScoreInput(string username, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("currentUser", username);
        form.AddField("userScore", score);
        
        using (UnityWebRequest www = UnityWebRequest.Post("http://ugrad.bitdegree.ca/~erinwaldram/ScoreIn.php", form))
        {
        
            yield return www.SendWebRequest();
            
            if (www.isNetworkError || www.isHttpError) 
            {
                //Debug.Log(www.error);
            }
            else 
            {
                //Debug.Log(www.downloadHandler.text);
            }
        }
    
    }
    
    
    
     public IEnumerator GetLeaderboard()
    {
        using(UnityWebRequest www = UnityWebRequest.Get("http://ugrad.bitdegree.ca/~erinwaldram/Leaderboard.php")) {
            yield return www.Send();
            
            if (www.isNetworkError || www.isHttpError) {
                //Debug.Log(www.error);
            }
            else {
            //Show the time results as text
                //Debug.Log(www.downloadHandler.text);
                s = (www.downloadHandler.text);
        }
    }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
