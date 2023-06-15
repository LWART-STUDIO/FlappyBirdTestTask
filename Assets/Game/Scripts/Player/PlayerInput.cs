using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private UnityAction _touchScreen;
        public UnityAction TouchScreen
        {
            get => _touchScreen;
            set => _touchScreen = value;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _touchScreen?.Invoke();
            }
        }
    }
}
