using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class SettingsGear : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OpenSettings);
        }

        private void OpenSettings()
        {
            UIPanelsControl.instanse.SettingsScreenEnable();
        }
    }
}
