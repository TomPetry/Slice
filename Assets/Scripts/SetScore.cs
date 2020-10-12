using System.Collections;
using System.Collections.Generic;
using Master;
using TMPro;
using UnityEngine;

public class SetScore : MonoBehaviour
{
    public GameObject thisScore;

    public GameObject playerHighscore;

    public GameObject globalHighscore;
    // Start is called before the first frame update
    private void Start()
    {
        MasterCounter master = GameObject.Find("GameMaster").GetComponent<MasterCounter>();        
        thisScore.GetComponent<TextMeshProUGUI>().text = master.finalScore.ToString();
        master.ResetScore();
        
        /*
         * Get current highest score out of db from current player
         * update if necessary
         */
        
        /*
         * Get highest score from all entries
         * update if necessary
         */
        
    }

}
