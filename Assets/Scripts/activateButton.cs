using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class activateButton : MonoBehaviour
{
    public Button button;
    public TMP_InputField field1, field2;


    private void Update()
    {
        if (!field1.text.Equals("") && !field2.text.Equals(""))
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
