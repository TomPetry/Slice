using System;
using System.Collections.Generic;
using System.Linq;
using Enemies;
using TMPro;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Master
{
    public class MasterCounter : MonoBehaviour
    {
        private int turnCount = 1;

        public List<GameObject> enemies = new List<GameObject>();
        public List<GameObject> toDestroy = new List<GameObject>();

        private List<GameObject> safeEnemies = new List<GameObject>();
        public float addAmount = 1;

        public int damageIncrease;
        public int shieldIncrease;
        public int bounceIncrease;

        public GameObject sword;

        public GameObject scoreText;
        private int _score = 0;
        public int finalScore = 0;

        public GameObject moneyText;
        public float money;

        private int _liveCount = 3;
        public GameObject livesText;

        private string _name;
        private string _token;

        public bool first = true;
        public int getScore()
        {
            return _score;
        }
        
        public void setName(string name)
        {
            _name = name;
        }

        public string getName()
        {
            return _name;
        }
        
        public void setToken(string token)
        {
            _token = token;
        }

        public string getToken()
        {
            return _token;
        }

        // Start is called before the first frame update
        public void AddToTurnCount()
        {
            turnCount++;
        }

        public int GetTurnCount()
        {
            return turnCount;
        }

        public void ReduceLife(int amount)
        {
            _liveCount -= amount;

            livesText.GetComponent<TextMeshProUGUI>().text = _liveCount.ToString();

            if (_liveCount <= 0)
            {
                finalScore = _score;
                SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
                Debug.Log("You dead");
            }
        }

        public int GetLife()
        {
            return _liveCount;
        }

        public void EndOfTurn()
        {
            checkForNulls();

            foreach (GameObject enemy in enemies)
            {
                if (enemy == null)
                {
                    toDestroy.Add(enemy);
                }
                else
                {
                    GeneralEnemyStats general = enemy.GetComponent<GeneralEnemyStats>();
                    if (general.GetEndOfTurnDamage())
                    {
                        general.ReduceHealthByAmount(general.GetEndOfTurnAmount());
                    }
                }
            }

            DestroyEverything();
            AddToTurnCount();
        }

        private void checkForNulls()
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy == null) toDestroy.Add(enemy);
            }
        }

        private void DestroyEverything()
        {
            foreach (GameObject enemy in toDestroy)
            {
                enemies.Remove(enemy);
                Destroy(enemy);
            }

            toDestroy.Clear();
        }

        public void AddToList(GameObject enemy)
        {
            safeEnemies.Add(enemy);

            foreach (GameObject safeEnemy in safeEnemies)
            {
                enemies.Add(safeEnemy);
            }
        }

        public void ClearList()
        {
            enemies.Clear();
        }

        public void UpdatePowerUps()
        {
            IEnumerable<PowerUps> powerUpses = FindObjectsOfType<MonoBehaviour>().OfType<PowerUps>();
            foreach (PowerUps powerUps in powerUpses)
            {
                powerUps.setNewSword(sword);
            }
        }

        public void ResetIncreases()
        {
            damageIncrease = 0;
            shieldIncrease = 0;
            bounceIncrease = 0;
        }

        public void AddToScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            if(scoreText != null)    scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + _score;
                
        }

        public void AddToMoney(int moneyToAdd)
        {
            money += moneyToAdd * addAmount;
            money = (float)Decimal.Round(moneyToAdd, 2);
            if(moneyText != null)    moneyText.GetComponent<TextMeshProUGUI>().text = money.ToString();
        }

        public void ResetScore()
        {
            _score = 0;
            turnCount = 0;
        }

        public  void WipeList()
        {
            enemies.Clear();
        }
    }
}