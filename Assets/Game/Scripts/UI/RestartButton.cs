using Game.Scripts.Level;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            SceneLoader.instanse.ReloadScene();
        }
    }
}
