using System.Collections;
using System.Collections.Generic;
using Scenes;
using UnityEngine;
using UnityEngine.UI;

public class AllButtonsGameOver : MonoBehaviour
{
    public Button restart;

    // Start is called before the first frame update
    private void Start()
    {
        restart.onClick.AddListener(ChangeScene.ChangeSceneToStart);
    }
}
