using System.Collections.Generic;
using Master;
using UnityEngine;

namespace Enemies
{
    public class SpawnEnemies : MonoBehaviour
    {
        [SerializeField] private int firstSpawn = 3;

        public List<GameObject> enemyKinds = new List<GameObject>();

        private MasterCounter _master;
        private void Start()
        {
            _master = GameObject.Find("GameMaster").GetComponent<MasterCounter>();
            SpawnEnemyAmount(firstSpawn);
            
        }

        public void SpawnEnemyAmount(int amount)
        {
            _master.ClearList();
            for (int i = 0; i < amount; i++)
            {
                int enemyIndex = Random.Range(0, enemyKinds.Count);
                GameObject rndEnemy = enemyKinds[enemyIndex];

                Vector2 point = CalculateRandomPoint();
                float randomRot = CalculateRandomAngles();
                GameObject enemy = Instantiate(rndEnemy, point,Quaternion.identity);
                enemy.transform.Rotate(new Vector3(0,0,randomRot));
                _master.AddToList(enemy);
            }
        }

        private Vector3 CalculateRandomPoint()
        {   
            
            Rect rect = GetComponent<RectTransform>().rect;
            float randomX = Random.Range(- rect.width/2, rect.width/2);
            float randomY = Random.Range(transform.position.y - rect.height/2, transform.position.y + rect.height/2);
            
            return new Vector3(randomX, randomY, 0);
        }

        private static int CalculateRandomAngles()
        {
            int randomY = Random.Range(0, 360);

            return randomY;
        }

        
    }
}