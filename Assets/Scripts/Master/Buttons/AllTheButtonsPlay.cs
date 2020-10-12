using Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace Master
{
    public class AllTheButtonsPlay : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button shop;
        
        private void Start()
        {
            if(shop) shop.onClick.AddListener(ChangeScene.ChangeSceneToShop);       
        }

    
    }
}
