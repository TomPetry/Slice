using Master;
using Sword;
using TMPro;
using UnityEngine;

namespace Scenes
{
    public class updateSword : MonoBehaviour
    {
        private MasterCounter masterCounter;

        public GameObject sword;

        public GameObject text;

        public GameObject money;

        public GameObject lives;
        // Start is called before the first frame update
        void Start()
        {
            masterCounter = GameObject.Find("GameMaster").GetComponent<MasterCounter>();
            masterCounter.sword = sword;

            text.GetComponent<TextMeshProUGUI>().text = masterCounter.getScore().ToString();
            money.GetComponent<TextMeshProUGUI>().text = masterCounter.money.ToString();
            
            masterCounter.scoreText = text;
            masterCounter.moneyText = money;
            masterCounter.livesText = lives;
            masterCounter.UpdatePowerUps();

            Init init = sword.GetComponent<Init>();
            init.damage += masterCounter.damageIncrease;
            init.fullShield += masterCounter.shieldIncrease;
            init.maxBounces += masterCounter.bounceIncrease;
            
            masterCounter.ResetIncreases();
            
            masterCounter.AddToScore(0);
            masterCounter.AddToMoney(0);
        }

    
    
    }
}
