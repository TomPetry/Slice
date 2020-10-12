using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustFieldNonUI : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 baseRes = new Vector3(1080, 2280, 1);
    public GameObject _panel;
    public bool scale;
    public float threshhold;

    void Start()
    {
        Vector3 curRes = new Vector3(Screen.width, Screen.height, 1);
        //Screen.SetResolution((int)baseRes.x,(int)baseRes.y,false);
        Debug.Log(curRes);
        Vector3 multi = new Vector3(curRes.x / baseRes.x, curRes.y / baseRes.y, 1);

        if (multi.x > threshhold || (multi.x < threshhold && scale))
        {
            _panel.transform.localScale =
                new Vector3(multi.x, _panel.transform.localScale.y, 1);
        }


        if (multi.y > threshhold || (multi.y < threshhold && scale))
        {
            _panel.transform.localScale =
                new Vector3(_panel.transform.localScale.x, multi.y, 1);
        }

        Debug.Log(multi);
    }
}