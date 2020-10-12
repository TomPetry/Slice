using System.Collections;
using System.Collections.Generic;
using Master;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSceneLeave : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.sceneUnloaded += WipeList;
    }

    // Update is called once per frame
    void WipeList(Scene scene)
    {
        MasterCounter masterCounter = GameObject.Find("GameMaster").GetComponent<MasterCounter>();
        masterCounter.WipeList();
    }
}
