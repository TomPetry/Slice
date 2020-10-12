using Sword;
using UnityEngine;

namespace Enemies.Colliders
{
    public class EnemyCollision : MonoBehaviour
    {
        private GeneralEnemyStats _general;
        // Start is called before the first frame update
        void Start()
        {
            _general = GetComponent<GeneralEnemyStats>();
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Sword")) _general.ReduceHealthByAmount(other.GetComponent<Init>().damage);
        }
    
    }
}
