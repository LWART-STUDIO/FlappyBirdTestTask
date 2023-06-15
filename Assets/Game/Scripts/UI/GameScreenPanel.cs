using System;
using Game.Scripts.Level;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class GameScreenPanel : Panel
    {
        [SerializeField] private GameObject _gear;

        private void Start()
        {
            GameStateControl.instanse.Started += HideGear;
            GameStateControl.instanse.Failed += ShowGear;
        }

        public void HideGear()
        {
            _gear.SetActive(false);
        }
        public void ShowGear()
        {
            _gear.SetActive(true);
        }

        private void OnDestroy()
        {
            GameStateControl.instanse.Started -= HideGear;
            GameStateControl.instanse.Failed -= ShowGear;
        }
    }
}
