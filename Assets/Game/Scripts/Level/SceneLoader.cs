using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Level
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader instanse;
        private void Awake()
        {
            if (instanse != null && instanse != this)
                Destroy(this);
            else
            {
                instanse = this;
                DontDestroyOnLoad(this);
            }
                
            
        }
        public void ReloadScene()
        {
           Scene scene = SceneManager.GetActiveScene();
           SceneManager.LoadScene(scene.name);
        }
    }
}
