using Master;
using TMPro;
using UnityEngine;

namespace Enemies
{
    public class GeneralEnemyStats : MonoBehaviour
    {
        private int _health;
        private int _maxHealth;
        public int _value;
        private TextMeshPro _text;
        private MasterCounter _master;

        private bool endOfTurnDamage;
        private int endOfTurnAmount;
        
        private void Start()
        {
            _text = GetComponentInChildren<TextMeshPro>();           
            _master = GameObject.Find("GameMaster").GetComponent<MasterCounter>();

            _health = _master.GetTurnCount() * 2;
            _maxHealth = _health;
            UpdateHealthText();
        }

        public void CheckHealth()
        {
            if (_health <= 0)
            {
                _master.toDestroy.Add(gameObject);               
            }
        }

        public void UpdateHealthText()
        {
            _text.text = "" + _health;
        }

        public void ReduceHealthByAmount(int amount)
        {
            _health -= amount;
            CheckHealth();
            UpdateHealthText();
        }

        public void FlipEndOfTurnDamage()
        {
            endOfTurnDamage = !endOfTurnDamage;
        }

        public void SetEndDamage(int amount)
        {
            endOfTurnAmount = amount;
        }

        public bool GetEndOfTurnDamage()
        {
            return endOfTurnDamage;
        }

        public int GetEndOfTurnAmount()
        {
            return endOfTurnAmount;
        }

        private void OnDestroy()
        {
            _master.AddToScore(_value * _maxHealth);
            _master.AddToMoney(_value * _maxHealth);
        }
    }
}
