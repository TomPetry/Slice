using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            GameObject[] masters = GameObject.FindGameObjectsWithTag("Master");

            if (masters.Length > 1)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        
    }
}