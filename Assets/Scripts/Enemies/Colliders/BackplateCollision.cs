using Sword;
using UnityEngine;

namespace Enemies.Colliders
{
    public class BackplateCollision : MonoBehaviour
    {
        private GeneralEnemyStats _general;

        private static bool frontHit, backHit;

        // Start is called before the first frame update
        private void Start()
        {
            _general = GetComponentInParent<GeneralEnemyStats>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Sword")) return;

            string colName = gameObject.name;

            switch (colName)
            {
                case "Front":

                    if (!backHit)
                    {
                        frontHit = true;
                        _general.ReduceHealthByAmount(other.GetComponent<Init>().damage);
                    } 
                    
                    break;
                case "Back":
                    if (!frontHit)
                    {
                        backHit = true;
                        Debug.Log("Hit Back nothing happens");
                    }
                    
                    break;
                default:
                    Debug.Log("No collisions");
                    break;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            string colName = gameObject.name;

            switch (colName)
            {
                case "Front":
                {
                    if(backHit) backHit = false;
                    break;
                }
                case "Back":
                {
                    if (frontHit) frontHit = false;
                    break;
                }
                default:
                {
                    Debug.Log("Something went wrong");
                    break;
                }
            }
        }
    }
}