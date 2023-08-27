using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Manager
{
    public class SceneLoaderManager : MonoBehaviour
    {
        public string[] scenesToLoad;

        private void Start()
        {
            foreach (string sceneName in scenesToLoad)
            {
                if (!SceneManager.GetSceneByName(sceneName).isLoaded)
                {
                    
                    SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
                }
            }
        }
    }
}