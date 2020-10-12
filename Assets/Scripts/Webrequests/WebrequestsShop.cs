using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Boomlagoon.JSON;
using Master;
using UnityEngine;
using UnityEngine.Networking;

public class WebrequestsShop : MonoBehaviour
{
    //private string link = "192.168.132.208";
    private string link = "http://localhost:3000";
    public GameObject sword;
    private MasterCounter _masterCounter;
    private GameObject _master;


    private void Start()
    {
        _master = GameObject.Find("GameMaster");
        _masterCounter = _master.GetComponent<MasterCounter>();
       
        StartCoroutine(GetUpgrades());               
    }

    private IEnumerator GetUpgrades()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", _masterCounter.getName());
        
        UnityWebRequest request = UnityWebRequest.Post(link + "/player/getUpgrades", form);
        request.SetRequestHeader("Authorization", _masterCounter.getToken());

        yield return request.SendWebRequest();
        
        if(request.isNetworkError) Debug.Log(request.error);
        else
        {
            JSONObject json = JSONObject.Parse(request.downloadHandler.text);
            GetUpgrades(json.GetArray("upgrades"));
        }
    }

    private void GetUpgrades(JSONArray arr)
    {
        foreach (JSONValue item in arr)
        {
            if (item.Obj.GetString("name").Equals("damage"))
            {
                DamagePower upgrade = _master.AddComponent<DamagePower>();
                upgrade.setLevel((int)item.Obj.GetNumber("level"));
            }
            
            if (item.Obj.GetString("name").Equals("money"))
            {
                MoneyPower upgrade = _master.AddComponent<MoneyPower>();
                upgrade.setLevel((int)item.Obj.GetNumber("level"));
            }
            
            if (item.Obj.GetString("name").Equals("slime"))
            {
                SlimePower upgrade = _master.AddComponent<SlimePower>();
                upgrade.setLevel((int)item.Obj.GetNumber("level"));
            }
            
            if (item.Obj.GetString("name").Equals("shield"))
            {
                ShieldPower upgrade = _master.AddComponent<ShieldPower>();
                upgrade.setLevel((int)item.Obj.GetNumber("level"));
            }
        }
    }
}
