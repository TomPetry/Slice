using System;
using System.Collections;
using System.Collections.Generic;
using Master;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Boomlagoon.JSON;

public class WebrequestScore : MonoBehaviour
{
    
    //private string link = "192.168.132.208";
    private string link = "http://localhost:3000";
    
    private MasterCounter _master;

    public TextMeshProUGUI ownHighscore, globalHighscore;

    private void Start()
    {
        _master = GameObject.Find("GameMaster").GetComponent<MasterCounter>();
        
        
        StartCoroutine(GetPlayerScore());
    }

    private IEnumerator GetPlayerScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", _master.getName());
        
        UnityWebRequest request = UnityWebRequest.Post(link + "/score/getByName",form);
        request.SetRequestHeader("Authorization",_master.getToken());

        yield return request.SendWebRequest();
        if(request.isNetworkError) Debug.Log(request.error);
        else
        {
            if (_master.finalScore > int.Parse(request.downloadHandler.text))
            {
                ownHighscore.text = _master.finalScore.ToString();
                StartCoroutine(UpdatePlayerScore());
            }
            else
            {
                ownHighscore.text = request.downloadHandler.text;                
                StartCoroutine(GetMaxScore());
            }        
        }
    }

    private IEnumerator GetMaxScore()
    {
        UnityWebRequest request = UnityWebRequest.Get(link + "/score");
        request.SetRequestHeader("Authorization",_master.getToken());
        
        yield return request.SendWebRequest();
        if(request.isNetworkError) Debug.Log(request.error);
        else
        {
            string res = request.downloadHandler.text;
            
            res = res.Remove(0, 1);
            res = res.Remove(res.Length - 1);
            
            Debug.Log(res);
            
            JSONObject json = JSONObject.Parse(res);
                        
            globalHighscore.text = json.GetNumber("highscore").ToString();
        }
    }

    public IEnumerator UpdatePlayerScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", _master.getName());
        form.AddField("highscore",_master.finalScore);
        
        UnityWebRequest request = UnityWebRequest.Post(link + "/player",form);
        
        request.SetRequestHeader("Authorization",_master.getToken());
        
        yield return request.SendWebRequest();
        if(request.isNetworkError) Debug.Log(request.error);
        else
        {
            Debug.Log(request.downloadHandler.text);
            StartCoroutine(GetMaxScore());
        }
    }
    
    
        
}
