using Master;
using Sword;
using UnityEngine;

namespace Enemies.Colliders
{
    public class MasterOfDefenseCollider : MonoBehaviour
    {
        private GeneralEnemyStats _general;
        private MasterCounter _master;

        // Start is called before the first frame update
        private void Start()
        {
            _general = GetComponentInParent<GeneralEnemyStats>();
            _master = GameObject.Find("GameMaster").GetComponent<MasterCounter>();
            _general.SetEndDamage(1);
            _general.FlipEndOfTurnDamage();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Sword"))
            {
                Debug.Log("No sword");
                return;
            }

            
            if (other.GetComponent<Init>().shield > 0)
            {
                other.GetComponent<Init>().shield--;
                Debug.Log("Shield Absorb");
            }
            else
            {
                 Debug.Log("Direct hit");
                 other.gameObject.GetComponent<Respawner>().respawn();
                 _master.ReduceLife(1);
            }
                
        }

    
    
    }
}
