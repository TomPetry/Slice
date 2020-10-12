using UnityEngine;

namespace Master
{
    public class AdjustField : MonoBehaviour
    {
        // Start is called before the first frame update
        Vector3 baseRes = new Vector3(1080,2280,1);
        public GameObject _panel;
        public bool scale;
        void Start()
        {        
            Vector3 curRes = new Vector3(Screen.width,Screen.height,1);
            //Screen.SetResolution((int)baseRes.x,(int)baseRes.y,false);
            Debug.Log(curRes);
            Vector3 multi = new Vector3(curRes.x/baseRes.x,curRes.y/baseRes.y,1);
            
            if (multi.x > 1 || (multi.x < 1 && scale))
            {
                _panel.GetComponent<RectTransform>().localScale = new Vector3(multi.x,_panel.GetComponent<RectTransform>().localScale.y,1);
            }
            

            if (multi.y > 1 || (multi.y < 1 && scale))
            {
                _panel.GetComponent<RectTransform>().localScale = new Vector3(_panel.GetComponent<RectTransform>().localScale.x,multi.y,1);
            }
            Debug.Log(multi);
        }
    }
}
