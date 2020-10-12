using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class ChangeScene : MonoBehaviour
    {
        // Start is called before the first frame update
        public static void ChangeSceneToShop()
        {
            SceneManager.LoadScene("ShopScene", LoadSceneMode.Single);
        }
    
        public static void ChangeSceneToGame()
        {
            SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
        }

        public static void ChangeSceneToStart()
        {
            SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
        }
    }
}
