using Sword;
using UnityEngine;

namespace Enemies.Colliders
{
    public class DeflectorCollision : MonoBehaviour
    {
        private GeneralEnemyStats _general;
        private GameObject _sword;

        private static bool frontHit, backHit;

        // Start is called before the first frame update
        private void Start()
        {
            _general = GetComponentInParent<GeneralEnemyStats>();
            _sword = GameObject.Find("Sword");
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

                        int x = 1;
                        int y = 1;
                        float z = gameObject.transform.rotation.eulerAngles.z;
                        if (z > -45 && z < 45 || z > 135 && z < 225) y = -1;
                        else x = -1;
                        _sword.GetComponent<Rigidbody2D>().velocity *= new Vector2(x,y);
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
