using System.Collections;
using System.Collections.Generic;
using Sword;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField]
    private GameObject respawner;
    
    [SerializeField]
    private GameObject _sword;

    public void respawn()
    {
        _sword.transform.position = respawner.transform.position;
        _sword.GetComponent<WallCollisions>().stopSword();
    }
}
