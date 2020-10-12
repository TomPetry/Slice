using System.Collections;
using System.Collections.Generic;
using Master;
using Scenes;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class WebrequestsStart : MonoBehaviour
{
    //private string link = "192.168.132.208";
    private string link = "http://localhost:3000";

    private MasterCounter _master;

    public TextMeshProUGUI error;

    private void Start()
    {
        _master = GameObject.Find("GameMaster").GetComponent<MasterCounter>();
    }

    public IEnumerator login(string name, string pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("password", pass);
        
        UnityWebRequest request = UnityWebRequest.Post(link + "/login", form);

        yield return request.SendWebRequest();
        
        if (request.isNetworkError) Debug.Log(request.error);
        else
        {           
            if (request.downloadHandler.text.Equals("please register first") || request.downloadHandler.text.Equals("Login failed"))
            {
                error.text = request.downloadHandler.text;
            }
            else
            {
                error.text = "";
                _master.setName(name);
                _master.setToken(request.downloadHandler.text);                
                ChangeScene.ChangeSceneToGame();
            }
            
        }       
    }

    public IEnumerator register(string name, string pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("password",pass);
        
        UnityWebRequest request = UnityWebRequest.Post(link + "/register",form);

        yield return request.SendWebRequest();
        
        if(request.isNetworkError) Debug.Log(request.error);
        else
        {
            Debug.Log(request.downloadHandler.text);
            StartCoroutine(login(name,pass));
        }
    }
}
