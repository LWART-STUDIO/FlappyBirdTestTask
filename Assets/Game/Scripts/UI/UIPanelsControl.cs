using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.SDK;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class UIPanelsControl : MonoBehaviour
    {
        public static UIPanelsControl instanse;

        [SerializeField] private Panel _startScreen;
        [SerializeField] private Panel _gameScreen;
        [SerializeField] private Panel _gameOverScreen;
        [SerializeField] private Panel _settingsScreen;
        private void Awake()
        {
            if (instanse != null && instanse != this)
                Destroy(this);
            else
                instanse = this;
        }

        private void Start()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            StartCoroutine(WaitData());
#else
            _startScreen.Show();
#endif
            _gameScreen.Show();
            _gameOverScreen.Hide();
            _settingsScreen.Hide();
        }

        public void StartScreenDisable()
        {
            _startScreen.Hide();
        }

        public void GameOverScreenEnable()
        {
            _gameOverScreen.Show();
        }

        public void SettingsScreenEnable()
        {
            _settingsScreen.Show();
        }

        public void SettingsScreenDisable()
        {
            _settingsScreen.Hide();
        }

        public SettingsScreenPanel GetSettingsScreenPanel()
        {
            return _settingsScreen as SettingsScreenPanel;
        }

        private IEnumerator WaitData()
        {
            yield return new WaitUntil(()=>AppsFlyerInit.instanse.Logs != "");
            yield return null;
            _startScreen.Show();
        }

    }
}
