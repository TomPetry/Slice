using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boomlagoon.JSON;
using Scenes;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Master
{
    public class AllTheButtonsShop : MonoBehaviour
    {
        //private string link = "192.168.132.208";
        private string link = "http://localhost:3000"; 
        
        public Button game;

        public Button damage;
        public Button money;
        public Button shield;
        public Button slime;

        private GameObject _master;
        // Start is called before the first frame update

        private void Start()
        {
            _master = GameObject.Find("GameMaster");
            game.onClick.AddListener(SubmitAndChange);
            damage.onClick.AddListener(() => addLevel("DamagePower", damage));
            money.onClick.AddListener(() => addLevel("MoneyPower", money));
            shield.onClick.AddListener(() => addLevel("ShieldPower", shield));
            slime.onClick.AddListener(() => addLevel("SlimePower", slime));
        }

        private void SubmitAndChange()
        {
            StartCoroutine(SetUpgrades());
            ChangeScene.ChangeSceneToGame();
        }

        private void addLevel(string comp, Button button)
        {
            PowerUps power = (PowerUps) _master.GetComponent(comp);
            MasterCounter masterCounter = _master.GetComponent<MasterCounter>();
            int price = getPrice(button);
            // ReSharper disable once UseNullPropagation
            if (!(price <= masterCounter.money))
            {
                Debug.Log("Not enough money");
                return;
            }

            masterCounter.money -= price;
            setPrice(button,price*2);
            
            if (power != null)
            {
                power.addLevel();
            }
            else
            {
                power = (PowerUps) _master.AddComponent(Type.GetType(comp));
                power.addLevel();
            }
        }

        private int getPrice(Button button)
        {
            TextMeshProUGUI text = button.transform.Find("Cost").gameObject.GetComponent<TextMeshProUGUI>();
            return int.Parse(text.text);
        }

        private void setPrice(Button button,int price)
        {
            TextMeshProUGUI text = button.transform.Find("Cost").gameObject.GetComponent<TextMeshProUGUI>();
            text.text = price.ToString();            
        }
        
        private IEnumerator SetUpgrades()
        {
            JSONObject json = new JSONObject();
            json.Add("name",_master.GetComponent<MasterCounter>().getName());
            
            JSONArray arr = new JSONArray();

            if (_master.GetComponent<DamagePower>())
            {
                JSONObject damage = new JSONObject();
                damage.Add("name","damage");
                damage.Add("level", _master.GetComponent<DamagePower>().getLevel());
            
                arr.Add(damage);
            }

            if (_master.GetComponent<MoneyPower>())
            {
                JSONObject money = new JSONObject();
                money.Add("name","money");
                money.Add("level", _master.GetComponent<MoneyPower>().getLevel());
            
                arr.Add(money);        }
        
            if (_master.GetComponent<SlimePower>())
            {
                JSONObject slime = new JSONObject();
                slime.Add("name","slime");
                slime.Add("level", _master.GetComponent<SlimePower>().getLevel());
            
                arr.Add(slime);
            }
        
            if (_master.GetComponent<ShieldPower>())
            {
                JSONObject shield = new JSONObject();
                shield.Add("name","shield");
                shield.Add("level", _master.GetComponent<ShieldPower>().getLevel());
            
                arr.Add(shield);
            }
        
            json.Add("upgrades",arr);
            
            Debug.Log(json.ToString());        
            byte[] bytes = Encoding.ASCII.GetBytes(json.ToString());

            UnityWebRequest request = UnityWebRequest.Post(link+"/player",UnityWebRequest.kHttpVerbPOST);
        
            UploadHandlerRaw uH= new UploadHandlerRaw(bytes);
            request.uploadHandler= uH;
            
            request.SetRequestHeader("Authorization", _master.GetComponent<MasterCounter>().getToken());
            request.SetRequestHeader("Content-Type", "application/json");
            
            yield return request.SendWebRequest();
        
            if(request.isNetworkError) Debug.Log(request.error);
            else Debug.Log(request.downloadHandler.text);
        }
    }
}